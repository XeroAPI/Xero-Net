## Console application example
This example uses a public application to create random contacts and invoices withing an organisation. It is a console application and the authentiation is done using oob callback. This will launch a browser on the users machine and prompt for the PIN. The token returned will be stored. If the applciation is run withing 30 minutes of the authorisation, the user will not be prompted to login.

Contacts are created with random names and addresses. Invoices are then made with random lines and random prices. A contacts is then attached to each invoice and the invoice created. Once this is done the contacts and invoices are read back and counts displayed.

Edit the app.config file to adjust the number of addresses, contacts, descriptions and invoices created.

You will need to enter appropriate values in the app.config file. As an exercise, change the application to private.
