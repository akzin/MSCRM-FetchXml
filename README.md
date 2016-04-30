# FluentAPI for CRM's FetchXML

FetchXML is powerful. However, xml construction by concatenating strings together, can be a real pain 

Tofi9.FetchXml is a library that allows you to write and execute FetchXML queries way easier:

    IOrganizationService organisationService = null; // CreateCrmService();

	// construct FetchXml using fluent-api
    FetchQuery query = new FetchQuery("lead")
        .Filter(f => f.Gt("budgetamount", 5000))
        .Attributes("fullname", "companyname", "budgetamount");

	// execution requires only one single line
    IReadOnlyList<Entity> result = query.RetrieveMultiple(organisationService);

    foreach(Entity entity in result)
    {
        Console.WriteLine($"{entity["fullname"]}: {entity["budgetamount"]}");
    }
