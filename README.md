# TDDemo
Demo of Test Driven Design.

This repository represents a theoretical application for calculating the amount a baby sitter is due at the end of the night. 
Granted no babysitter on the planet would know how to use it but we'll put a simple command line interface on it. 

The problem Domain comes from https://gist.github.com/jameskbride/5482722

At time of writing the clients description looks as follows.

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

## Issue 1
So "gets paid for full hours (no fractional hours)" so if the babysitter arrives at 11:30 the child goes to bed at 11:45 and the parents show back up at 12:15 how much does the babysitter make?

*Option 1 Rule applies to fractional periods
 - .25 => 1 hour pre bed time
 - .25 => 1 hour pre midnight
 - .25 => 1 hour from midnight to end of job
so $12 + $8 + $16 = $36 for 45 minutes of work? 

*Option 2 Rule applies to total hours worked
 - .25 => 1 hour pre bed time
 - .25 => 1 hour pre midnight
 - .25 => 1 hour midnight to end of job
 - .75 => 1 hour total time worked

1 hour was worked. The highest rate during that hour was $16 so 1 x $16 = $16

We'll assume Option#2 as common sense would tend to dictate that is the answer but it also might be worth asking the client since it does have a fairly big impact on the business logic.

## Issue 2 (Came up while coding) "gets paid $12/hour from start-time to bedtime"
What happens if the kids are real brats and dont go to bed till 1 am?

*Option 1 Sitter makes pre bedtime rate Until they go to bed then shifts to after midnight.

*Option 2 Sitter makes after midnight rate regardless.

Again I went with option 2 since its the higher rate.

So take a look at the push history to see the incremental as we go from Napkin to CLI.

# How to Compile - MSBuild
  - Down load the code from this repository
  - To start with you'll need to ensure you have MSBuild if Visual Studio is installed you just need to open a Visual Studio Command Prompt and the pathing should all be setup for you this was created with VS2015 so that or any follow on version should work.
  - Change the directory to the location you downloaded the Source code. You should be sitting @ the root of XamarinTDDemo
  - Type MSBuild XamarinTDDemo.CLI.sln
  - Once the code Finishes compiling the Code cd to XamarinTDDemo.CLI\bin\Debug
  - type XamarinTDDemo.CLI.exe

# Note
When I first started this TDDemo I intended to carry it on through and Drive the UI using Xamarins UI tests and potentially put it up in the Google App Store as a Beta. Unfortunately it looks like the Xamarin UI Test client still needs a bit of work so I just left it at the CLI.