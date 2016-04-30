using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tofi9.FetchXml.ObjectModel;

namespace Tofi9.FetchXml.Querying
{
    public class FetchQuery
    {
        FetchXmlObject fetch;

        public FetchQuery(string entity)
        {
            fetch = new FetchXmlObject
            {
                Entity = new FetchEntity { Name = entity }
            };
        }

        public FetchQuery AllAttributes()
        {
            fetch.Entity.Attributes.Add(new AllAttributes());
            return this;
        }

        public FetchQuery Attributes(params string[] attributes)
        {
            fetch.Entity.Attributes.AddRange(attributes.Select(x => new ObjectModel.Attribute { Name = x }));
            return this;
        }

        public FetchQuery Filter(Action<FetchFilter> filterFn)
        {
            var filter = fetch.Entity.Filter;
            if (filter == null)
            {
                fetch.Entity.Filter = filter = new Filter();
            }

            FetchFilter.Apply(filter, filterFn);

            return this;
        }

        public override string ToString()
        {
            return this.fetch.ToString();
        }

        public IReadOnlyList<Entity> RetrieveMultiple(IOrganizationService service)
        {
            var fetch = this.ToString();
            var result = service.RetrieveMultiple(new FetchExpression(fetch)).Entities.ToList();
            return result;
        }
    }

    public class FetchFilter
    {
        private Filter filter;

        public FetchFilter(Filter filter)
        {
            this.filter = filter;
        }

        public FetchFilter SubFilterOr(Action<FetchFilter> filterFn)
        {
            var subFilter = new Filter { Type = FilterType.Or };

            filterFn(new FetchFilter(subFilter));

            filter.Filters.Add(subFilter);
            return this;
        }

        public FetchFilter SubFilterAnd(Action<FetchFilter> filterFn)
        {
            var subFilter = new Filter { Type = FilterType.And };

            filterFn(new FetchFilter(subFilter));

            filter.Filters.Add(subFilter);
            return this;
        }

        public FetchFilter Condition(string attribute, ObjectModel.ConditionOperator op, object value)
        {
            filter.Conditions.Add(new Condition
            {
                Attribute = attribute,
                Operator = op,
                Value = ObjectModel.Condition.TranslateValueToString(value)
            });

            return this;
        }

        public FetchFilter Eq(string attribute, object value)
        {
            Condition(attribute, ObjectModel.ConditionOperator.Eq, value);
            return this;
        }
        public FetchFilter Gt(string attribute, object value)
        {
            Condition(attribute, ObjectModel.ConditionOperator.Gt, value);
            return this;
        }

        public FetchFilter Like(string attribute, object value)
        {
            Condition(attribute, ObjectModel.ConditionOperator.Like, value);
            return this;
        }

        public static void Apply(Filter filter, Action<FetchFilter> filterFn)
        {
            filterFn(new FetchFilter(filter));
        }
    }
}
