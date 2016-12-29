# Xamarin TDDemo
Demo of Test Driven Design.

I'm a big fan of TDD but when it comes to Xamarin that can be problematic because of the difficulty of testing the UI when its running in a simulator. This repository represents a theortical application for calculating the amount a baby sitter is due at the end of the night. We'll start with a simple commandline interface. 
Once thats completed we'll move up implementing the same tests at a UI level.

The problem Domain comes from https://gist.github.com/jameskbride/5482722

at time of writing the clients description looks as follows.

# Babysitter Kata

Background
----------
This kata simulates a babysitter working and getting paid for one night.  The rules are pretty straight forward:

The babysitter 
- starts no earlier than 5:00PM
- leaves no later than 4:00AM
- gets paid $12/hour from start-time to bedtime
- gets paid $8/hour from bedtime to midnight
- gets paid $16/hour from midnight to end of job
- gets paid for full hours (no fractional hours)


Feature:
As a babysitter
In order to get paid for 1 night of work
I want to calculate my nightly charge

#Assumptions

So anytime a client says "pretty straight forward" I cringe its almost like they are saying hey this is so obvious you really shouldn't have any questions. Because I almost always do.
So "gets paid for full hours (no fractional hours)" so if the babysitter arrives at 11:30 the child goes to bed at 11:45 and the parents show back up at 12:15 how much does the babysitter make?

*Option 1 Rule applies to fractional periods
.25 => 1 hour pre bed time
.25 => 1 hour pre midnight
.25 => 1 hour end of job
so $12 + $8 + $16 = $36 for 45 minutes of work? 

*Option 2 Rule applies to total hours worked
.25 => 1 hour pre bed time
.25 => 1 hour pre midnight
.25 => 1 hour end of job

.75 => 1 hour total time worked
1 hour was worked the highest rate during that hour was $16 so 1 x $16 = $16

We'll assume Option#2 as common sense would tend to dictate thats the answer but it also might be worth asking the client since it does have a fairly big impact on the business logic.

So take a look at the push history to see the incrementals as we go from Napkin to Google store. Hey might even post it up to the store just for the fun of it. 



