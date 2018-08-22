Change the connection string inside “Banking\BankingService\BankingService\web.config” to point to the local project location.
      Replace “~” with the local project path in AttachDBFilename in web.config.
Run BankingServices solution to start the services.
Update Service Reference in both CosoleApp and WebAppASP inside BankingApplication solution.
Run ConsoleApp or WebAppAsp in the BankingApplication solution to test the various features through a console application or through a web page.
