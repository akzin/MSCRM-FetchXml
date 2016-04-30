# FluentAPI for CRM's FetchXML

FetchXML is powerful, but is a pain to construct using string concatenation. 

Tofi9.FetchXml is a library that focuses on writing and executing FetchXML queries easier:

    IOrganizationService organisationService = null; // CreateCrmService();


    FetchQuery query = new FetchQuery("lead")
        .Filter(f => f.Gt("budgetamount", 5000))
        .Attributes("fullname", "companyname", "budgetamount");


    IReadOnlyList<Entity> result = query.RetrieveMultiple(organisationService);
    foreach(Entity entity in result)
    {
        Console.WriteLine($"{entity["fullname"]}: {entity["budgetamount"]}");
    }
