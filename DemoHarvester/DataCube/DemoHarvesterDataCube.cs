using System;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using Ilc.BusinessObjects;
using Ilc.DataCube.Contract;
using Ilc.BusinessObjects.Common;

namespace DemoHarvester.DataCube
{
    [Export(typeof(IDataCube))]
    public class DemoHarvesterDataCube : IDataCube
    {
        public void ResolveInfoPoints(InfoPointProcess context, IInfoPointDataInterface dataInterface)
        {
            throw new NotImplementedException();
        }

        public List<ObjectType> GetCollectTypes(string tenant)
        {
            return new List<ObjectType>
            {
                new ObjectType(typeof(News), "News")
            };
        }

        public void CollectInformations(InformationProcess context, InfoPoint infoPoint, IInformationDataInterface dataInterface)
        {
            //Get the company out of the InfoPoint
            var company = infoPoint.Value as Company;

            //If there is no company in there -> do nothing!
            if (company == null)
                return;

            //Fetch the news for that company
            var news = FetchNewsForCompany(company);

            //Return the values
            dataInterface.Insert(news);
        }

        public List<News> FetchNewsForCompany(Company company)
        {
            /*
             * Here we get the company object which includes the name and some meta information. This could be used
             * to retrieve news for that specific company out of a DB, over an API, or whatever you can think of.
             *
             * However for our demo case we always return the same static list of news...
             */
            var news = new List<News>();

            //Create an article...
            var articleOne = new News()
            {
                Title = "Weltpremiere des ILC Dashboard auf der größten Microsoft Messe, Ignite 2015",
                Description = "Unter diesem Motto findet in diesem Jahr die Microsoft Ignite in Chicago statt. Die besten und ...",
                Url = "https://ilctechnologies.wordpress.com/2015/04/14/weltpremiere-des-ilc-dashboard-auf-der-grosten-microsoft-messe-ignite-2015/",
                Source = "ILC Technologies Blog",
                Date = new DateTime(2015, 4, 14)
            };
            news.Add(articleOne);

            //Create another article...
            var articleTwo = new News()
            {
                Title = "ILC wird in die IT-Bestenliste gewählt!",
                Description = "Endlich sind sie da, die heiß ersehnten IT-Bestenlisten! Beim INNOVATIONSPREIS- IT 2015  ...",
                Url = "https://ilctechnologies.wordpress.com/2015/04/02/ilc-wird-in-die-it-bestenliste-gewahlt/",
                Source = "ILC Technologies Blog",
                Date = new DateTime(2015, 4, 2)
            };
            news.Add(articleTwo);

            return news;
        }

        public void ExpandInformations(InformationProcess context, List<string> informationIds, IInformationDataInterface dataInterface)
        {
            throw new NotImplementedException();
        }
    }
}
