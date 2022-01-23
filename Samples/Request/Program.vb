Imports Sdk4me

Module Program

    Public Sub Main()
        'AUTHENTICATION TOKENS
        Dim token As New AuthenticationToken("31fd31927a8b...", AuthenticationType.BearerAuthentication)

        'INIT CLIENT
        Dim client As New Sdk4meClient(token, "wna", EnvironmentType.Quality)

        'GET /requests EXAMPLE
        Example1(client)
        Console.WriteLine($"Token status: {token.RequestsRemaining}/{token.RequestLimit}")
        Console.WriteLine()

        'CREATE REQUEST
        Example2(client)
        Console.WriteLine($"Token status: {token.RequestsRemaining}/{token.RequestLimit}")
        Console.WriteLine()
    End Sub

    Private Sub Example1(ByRef client As Sdk4meClient)
        Try
            'SEARCH FILTER
            Dim filters As New FilterCollection
            filters.Add(New Filter("UpdatedAt", FilterCondition.GreaterThanOrEqualsTo, Date.Now.AddDays(-30)))

            'SEARCH AND ONLY LOAD SPECIFIED ATTRIBUTES
            Dim requests = client.Requests.Get(filters)

            'REQUESTS
            For Each request As Request In requests
                Console.WriteLine($"{request.ID} - {request.Subject}")
            Next
            Console.WriteLine()

        Catch ex As Sdk4meException
            Console.WriteLine($"Error: {ex.Message}")
            Console.WriteLine($"Details: {ex.DetailedMessage}")
        End Try
    End Sub

    Private Sub Example2(ByRef client As Sdk4meClient)
        Try
            'GET ME
            Dim myself As Person = client.People.GetMe()

            If myself IsNot Nothing Then

                Dim request As New Request With {
                    .RequestedBy = myself,
                    .RequestedFor = myself,
                    .Subject = "A request created via the Skd4me client",
                    .Impact = RequestImpactType.Low,
                    .Category = RequestCategoryType.Incident,
                    .Note = "Additional information about the request",
                    .ServiceInstance = New ServiceInstance With {
                        .ID = 123456
                    }
                }

                Console.WriteLine("Create a new request")
                request = client.Requests.Insert(request)
                Console.WriteLine($"Request #{request.ID} successfully created.")
            End If

        Catch ex As Sdk4meException
            Console.WriteLine($"Error: {ex.Message}")
            Console.WriteLine($"Details: {ex.DetailedMessage}")
        End Try
    End Sub

End Module

