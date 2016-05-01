## Tests for the Core API
These are really code snippets in the form of runnable tests. The examples for each of the endpoints in [Developer](http://developer.xero.com/documentation/api/api-overview/) have been turned into individual tests.

## Getting the tests working

To get all tests to pass you'll need a Xero account and a [private application](http://developer.xero.com/documentation/getting-started/private-applications/). 

1. generate a [public/private keypair](http://developer.xero.com/documentation/advanced-docs/public-private-keypair/)
1. copy `public_privatekey.pfx` generated in (1) to `CoreTests\Resources\cert/`
1. [register a private application](https://app.xero.com/Application). (Upload the `.cer` file generated in (1).)
1. update `App.config` with consumer key and secret 

These will run against the live API, so will cause your rates to be reached if all are run at once.
