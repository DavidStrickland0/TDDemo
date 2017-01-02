* So what would I want to de better next time?
Better commit comments. No matter how much you put it's never enough. But this time around I really skimped. 
Checking in Before and after each test isn't really normal and likely contributed to the lack of commit messages.

* What dont I like?
The resolution toward the end for handling overlap time. To much complexity came in and its something a quick chat 
with the stake holders could have fixed. Without that conversation the overlap time should be based on which rate is higher not hard coded 
to assume Midnight Time > Kids Awake > Kids Asleep. Put in a bunch of energy to allow the rates to change only to hamsting it with the overlap logic.

* Outcome
Really enjoyed it. Havent developed just for the art of it in a while and forgot how much fun it can be. 

The addition of the Xamarin UI Tests was disappointing. Even the simplest Xamarin UI test can take 30-90 seconds to run. The small incremental tests that often result from the standard TDD workflow can quickly result in time consuming test runs. The few tests created for this small TDD test can take up to 8 minutes to run and there arent even as many tests as there should be. A screen of this complexity should likely have 10 to 20 tests to cover all the possitive and negitive tests. This resulted in the tendency to only run the current test as well as tendency to make tests more complex because of the incemental time increase of each new test. At 30 secs a test it would be very easy to get hours of tests in a complex application.

