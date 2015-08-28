using System;
using System.Linq;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;

namespace CoreTests.Integration.Contacts
{
    public abstract  class ContactsTest : ApiWrapperTest
    {
        private TrackingCategory trackingCat;
        private bool wasTCCreated = false;

        protected Contact Given_a_contact()
        {
            var contact = Api.Create(new Contact
            {
                Name = "Peter " + Random.GetRandomString(10)
            });
            return contact;
        }

        protected TrackingCategory findOrCreateTC(string OptionName, string TCName)
        {
            trackingCat = Api.TrackingCategories.GetAll().FirstOrDefault();
            if (trackingCat == null || trackingCat.Options.FirstOrDefault() == null)
            {
                var option1 = new Option()
                {
                    Id = Guid.Empty,
                    Name = OptionName,
                    Status = TrackingOptionStatus.Active
                };


                trackingCat = Api.TrackingCategories.Create(new TrackingCategory()
                {
                    Name = TCName,
                    Status = TrackingCategoryStatus.Active
                });


                Api.TrackingCategories[trackingCat.Id].Add(option1);

                trackingCat = Api.TrackingCategories.GetByID(trackingCat.Id);
                wasTCCreated = true;
            }
            return trackingCat;
        }

        protected void deleteCreatedTC(TrackingCategory tc)
        {
            if (wasTCCreated)
            {
                Api.TrackingCategories.Delete(trackingCat);
                wasTCCreated = false;
            }
        }
    }
}
