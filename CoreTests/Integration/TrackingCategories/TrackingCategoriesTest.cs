using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using NUnit.Framework;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Model.Types;

namespace CoreTests.Integration.TrackingCategories
{
    public class TrackingCategoriesTest : ApiWrapperTest
    {
        private Invoice invoice_;

        public TrackingCategory Given_a_TrackingCategory_with_Options()
        {
            var trackingCategory = Given_a_TrackingCategory();

            var option1 = Given_a_tracking_option();
            var option2 = Given_a_tracking_option();

            Api.TrackingCategories[trackingCategory.Id].Add(option1);
            Api.TrackingCategories[trackingCategory.Id].Add(option2);

            var result = Api.TrackingCategories.GetByID(trackingCategory.Id);

            return result;
        }

        public TrackingCategory Given_a_TrackingCategory()
        {
            var trackingCategory = Api.TrackingCategories.Add(new TrackingCategory
            {
                Name = "TheJoker " + Guid.NewGuid(),
                Status = TrackingCategoryStatus.Active
            });

            return trackingCategory;
        }

        public Option Given_a_tracking_option()
        {
             

            return new Option()
            {
                Id = Guid.Empty,
                Name = "Option " + Guid.NewGuid(),
                Status = TrackingOptionStatus.Active
            };
        }

        public List<Option> Given_a_tracking_options()
        {
            List<Option> options = new List<Option>();

            options.Add(Given_a_tracking_option());
            options.Add(Given_a_tracking_option());

            return options;
        }

        public void Given_approved_invoice_with_tracking_option(TrackingCategory ct, InvoiceType type = InvoiceType.AccountsPayable, InvoiceStatus status = InvoiceStatus.Draft)
        {
            Guid category = ct.Id;
            string name = ct.Name;
            string option = ct.Options.FirstOrDefault().Name;

            var inv = Api.Create(new Invoice
            {
                Contact = new Contact { Name = "Wayne Enterprises" },
                Type = type,
                Date = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(90),
                LineAmountTypes = LineAmountType.Inclusive,
                Status = status,
                Items = new List<LineItem>
                {
                    new LineItem
                    {
                        AccountCode = "200",
                        Description = "Good value item",
                        LineAmount = 100m,
                        Tracking = new ItemTracking
                            {
                                new ItemTrackingCategory
                                {
                                    Id = category,
                                    Name = name,
                                    Option = option
                                }
                            }
                    }
                }

            });

            inv.Status = InvoiceStatus.Authorised;
            invoice_ = Api.Update(inv);
        }

        public Invoice Given_Invoice_is_voided()
        {
            invoice_.Status = InvoiceStatus.Voided;
            return Api.Update(invoice_);
        }

        public TrackingCategory Given_Tracking_Category_is_deleted(TrackingCategory categoty)
        {
            var trackingCategory = Api.TrackingCategories.Delete(categoty);

            Assert.True(trackingCategory.Status == TrackingCategoryStatus.Deleted);

            return trackingCategory;
        }

        public Option Given_Tracking_CategoryOption_is_deleted(TrackingCategory category, Option option)
        {
            var result = Api.TrackingCategories.DeleteTrackingOption(category, option);

            return result;
        }
    }
}
