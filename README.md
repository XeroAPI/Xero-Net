Xero-Net-Notes
========
Added support for https://developer.xero.com/documentation/api/history-and-notes via an extension method. It has a low risk of breaking existing APIs (as it doesn't change them) and yet provides a wide range of support for existing and new API and objects. It obviously may break if the object in question doesn't support history. I've added two basic tests against the contact object and added some very light XML comments.

Example of usage:

        using Xero.Api.Common;
        
        var contact = Api.Contacts.Find(new Guid("..."));
        var allHistory = Api.Contacts.GetHistory(contact);
        var newHistory = Api.Contacts.AddNote(contact, "History was reviewd.");
