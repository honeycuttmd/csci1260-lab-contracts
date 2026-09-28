# CSCI 1260 Lab 3: Built-In Interfaces

**Name:** Madison Honeycutt  
**Section:** 002  
**Track:** Track A - The Shop  
**World:** River City Supply, continuing the shop world from the inheritance lab  
**Language:** C#

## About this Lab

This program demonstrates built-in contracts using shelf count records from River City Supply. It includes equality and hash codes, natural ordering with `IComparable<T>`, alternate sorting with `IComparer<T>`, and cleanup with `IDisposable`.

## How to Run

Open and run the program in Visual Studio. The program will print the four contract demonstrations to the console and creates a `count-log.txt` file.

## Equality Design Question

Treating records 1 and 5 as equal makes sense if they are two counts of the same shelf location, since the aisle and slot identify the location even if the amount of inventory or its dollar value has changed because of sales, restocking, or a price change. It would be a bug if that same shelf location was later used for a different product or if the store needed to keep each count as a separate historical record. In that case, `ValueOnHand` would need to be included in `Equals` and `GetHashCode`, and `CompareTo` would also need to be updated so the natural ordering stays consistent with the new definition of equality.

## Unfinished Work

None.