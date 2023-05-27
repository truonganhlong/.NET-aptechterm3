# .NET-aptechterm3
this is my term 3 project about asp.net mvc and asp.net web api in C#


Step 1: Run Sql Server, then execute OMR.sql file
Step 2: Extract project in SourceCode folder
Step 3: Go to file appsettings.json in OMR_Service project then replace your connection string
Step 4: Go to file OMRDBContext.cs in OMR_Service Project, EF folder then replace your connection string
Step 5: Run OMR_Service project to get your base url then go to Web.config in OMR_Client project, replace your baseurl in Key BaseUrl
Step 6: Ok now you can run our project. You can register account as customer through signup site. I also have a sample account for customer:
Phone : 0357715583
Password: 123456

Our project only have 1 Admin account. This admin account can create many employee account. This is admin account, login in login as employee
Username: Admin
Password: 123456
After that you can create new employee, and go to register tab in admin website to register an employee account.

Note: - Sometime you run and catch some exception in try-catch. Just continue because this is custom code to check admin or employee. The project still works well.
-In our project, there are 3 service providers: Viettel, Vinaphone, Mobiphone. When you submit target’s phone to send top-up, please fill 10 numbers and begin with these below numbers to recognize its service provider:
	+Viettel: begin with 035, 036, 037, 032, 033, 034, 038, 039, 096, 097, 098, 086.
	+Vinaphone: begin with 088, 091, 094, 083, 084, 085, 081, 082.
	+Mobiphone: begin with 089, 090, 093, 070, 079, 077, 076, 078.
