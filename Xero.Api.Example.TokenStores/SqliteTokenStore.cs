using System.Data.SQLite;
using System.IO;
using System.Linq;
using Xero.Api.Example.TokenStores.Dapper;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;

namespace Xero.Api.Example.TokenStores
{
    public class SqliteTokenStore : ITokenStore
    {
        private const string FileName = "tokens.sqlite";
        private const string ConnectionString = "Data Source=" + FileName + ";Version=3;";

        public SqliteTokenStore()
        {
            if (!File.Exists(FileName))
            {
                CreateEmptyDatabase();
            }
        }

        private void CreateEmptyDatabase()
        {
            SQLiteConnection.CreateFile(FileName);

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                connection.Execute(
                    @"
CREATE TABLE tokens (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId TEXT NOT NULL,
    OrganisationId TEXT NOT NULL,
    ConsumerKey TEXT NOT NULL,
    ConsumerSecret TEXT NOT NULL,
    TokenKey TEXT NOT NULL,
    TokenSecret TEXT NOT NULL,
    ExpiresAt DATETIME,
    Session TEXT,
    SessionExpiresAt DATETIME)");
            }
        }
        
        public IToken Find(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return null;

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var token = connection.Query<Token>(
                    @"SELECT UserId, OrganisationId, ConsumerKey, ConsumerSecret, TokenKey, TokenSecret, ExpiresAt, Session, SessionExpiresAt
                    FROM tokens
                    WHERE UserId = @UserId",
                    new
                    {
                        userId
                    }).FirstOrDefault();

                if (null != token && token.ExpiresAt.HasValue)
                {
                    // This is done because SQLite seems to be storing it as local time.
                    token.ExpiresAt = token.ExpiresAt.Value.ToUniversalTime();
                }

                return token;
            }
        }

        public void Add(IToken token)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                connection.Execute("DELETE FROM tokens WHERE OrganisationId = @OrganisationId", new
                {
                    token.OrganisationId
                });

                connection.Execute(@"INSERT INTO tokens (UserId, OrganisationId, ConsumerKey, ConsumerSecret, TokenKey, TokenSecret, ExpiresAt, Session, SessionExpiresAt)
                    VALUES (@UserId, @OrganisationID, @ConsumerKey, @ConsumerSecret, @TokenKey, @TokenSecret, @ExpiresAt, @Session, @SessionExpiresAt)", token);
            }
        }

        public void Delete(IToken token)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                connection.Execute("DELETE FROM tokens WHERE OrganisationId = @OrganisationId", new
                {
                    token.OrganisationId
                });
            }
        }
    }
}
