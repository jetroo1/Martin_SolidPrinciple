# SOLID Refactor - Order Desk

I built the starter app from the handout first and ran it before changing anything. It
works, but the code is bad. One button method does four different things, the form itself
opens the database and the email server, and all the buttons share one `total` variable.

When I tested it I found 3 bugs:

1. Calculate crashes if you don't pick a discount first, because `SelectedItem` is null.
2. Print and Email show the old total. I changed a price from 100 to 200 and Print still
   showed ₱250 instead of ₱450.
3. Save Order crashes because I don't have SQL Server installed on my laptop.

After that I refactored it one principle at a time.

## Single Responsibility

`btnCalculate_Click` was doing 4 jobs at once: reading the grid, computing the total,
choosing the discount, and updating the label. I moved the computing part into
`OrderCalculator` and made an `OrderItem` class for the rows.

I also deleted the shared `total` field. Now every button computes the total again when
you click it, so bug 2 is fixed. Bug 1 got fixed too, because there is only one place now
that reads the dropdown, so I only had to handle the null once instead of in four places.

## Open/Closed

Before this, adding a discount meant editing the if/else inside the form. Now every
discount is its own class that implements `IDiscountStrategy`, and they are all listed in
`DiscountStrategyFactory`. The dropdown gets its items from that list.

So if I want to add an Employee discount, I just write a new class and add one line to the
factory. I don't have to open `Form1.cs` or `OrderCalculator.cs` at all.

## Liskov Substitution

I put this one in its own section below since the handout asks questions about it.

## Interface Segregation

I could have made one big `IOrderService` with Save, Email and Print inside it. I didn't.
I made three separate interfaces instead, `IOrderRepository`, `IInvoiceSender` and
`IInvoicePrinter`, and each one only has a single method.

If it was one big interface, `MessageBoxInvoicePrinter` would be forced to implement Save
and Send also, and I would have to throw `NotImplementedException` on both of them. That
is the same problem as the Liskov part below.

## Dependency Inversion

`Form1` used to create `SqlConnection` and `SmtpClient` by itself, so the app could not
even run without a database. Now the constructor takes 5 interfaces and `Form1` doesn't
know any of the real classes.

`CompositionRoot.cs` is the only file that creates the real objects. There is one flag
there that switches the whole app between the real SQL and SMTP and the fake ones. That is
how bug 3 got fixed. Save Order works now even without SQL Server.

## Part 3: the Liskov crash

I added `FreeShippingDiscount` from the handout and registered it in the factory the same
way as the other four discounts. It compiled with no errors and it even showed up in the
dropdown beside None, Student, Senior and BlackFriday. Then I picked it, clicked
Calculate, and the app died with:

```
NotSupportedException: Doesn't apply to order totals, only shipping!
```

**Why does this break the substitutability promise of `IDiscountStrategy`?**

Because the interface is a promise, not only a method signature. The promise is: give me a
total and I will give you back a total. `FreeShippingDiscount` has the correct signature so
it compiles, but it throws an exception instead of returning anything. `OrderCalculator`
did not change at all and there is nothing wrong with it. It just got handed something
that is an `IDiscountStrategy` by name only, and it crashed while running correct code.

**What does LSP say about subtypes that can't be swapped in safely?**

They are not really subtypes. If the caller has to check what the object actually is
first, like `if (discount is FreeShippingDiscount)`, or wrap every call in a try/catch,
then that class does not belong behind that interface. Making a class implement an
interface just because the method signature fits is the mistake.

So I did not fix it with a try/catch. I fixed it by using a different abstraction. Free
shipping is not a discount on the order total, it is a rule about the shipping fee. So I
made `IShippingRule` and put it there as `FreeShippingRule`, where returning 0 is a normal
answer and it can be swapped with `FlatRateShippingRule` without breaking anything.

I kept `FreeShippingDiscount.cs` in the project so the violation can still be seen, but I
removed it from the factory so the app does not crash anymore.

## Part 5: FakeOrderRepository

`FakeOrderRepository` is useful for testing because I can run the whole save process and
then check what would have been saved using `SaveCount` and `LastSaved.Total`, without
needing SQL Server to be running. The tests are fast, I can run them as many times as I
want, and nothing gets written into a real database.

## How to run

Open `OrderDesk.sln` in Visual Studio and press F5.

The app uses the fakes by default so it does not need a database or a mail server. If you
want the real ones, change `UseRealInfrastructure` to true in `CompositionRoot.cs`. The
table it expects is:

```sql
CREATE TABLE Orders (Id INT IDENTITY PRIMARY KEY, Email NVARCHAR(256), Total DECIMAL(18,2));
```
