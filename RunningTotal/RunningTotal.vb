Option Strict On
Option Explicit On
Option Compare Text
'TODO 
'[x] keep track of transactions in a function called RunningTotal()
'[x] get the current total as needed
'[x] provide a way to clear/zero the total
'[x] display transactions and running total formatted as currency
'[x] super bounus: create a method to include sales tax to the transaction
Module RunningTotal

    Sub Main()
        Dim userInput As String
        Dim quit As Boolean = False
        Dim purchaceAmount As Decimal

        Do
            Console.WriteLine("Please enter an amount of money you would like to lose.")
            userInput = Console.ReadLine
            Console.WriteLine()
            If userInput = "C" Then
                purchaceAmount = 0
                RunningTotal(purchaceAmount).ToString("C")
                Console.WriteLine("You've cleared your cart.")
            ElseIf userInput = "Q" Then
                quit = True
            ElseIf userInput <> "Q" Then
                Try
                    purchaceAmount = CDec(userInput)
                    Console.Write("Before tax: ")
                    Console.WriteLine(RunningTotal(purchaceAmount).ToString("C"))
                    Console.WriteLine()
                Catch ex As Exception
                    Console.WriteLine("Not a valid number")
                End Try
            End If
        Loop Until quit = True

        Console.Clear()
        Console.WriteLine($"The total is: {(TotalTaxed(RunningTotal(1) - 1) + RunningTotal(1) - 2):C}")
        Console.WriteLine("Have a nice day!")
    End Sub

    Function RunningTotal(currentNumber As Decimal) As Decimal
        Static _runningTotal As Decimal
        If currentNumber = 0 Then
            _runningTotal -= _runningTotal
        ElseIf currentNumber = currentNumber Then
            _runningTotal += currentNumber
        End If
        Return _runningTotal
    End Function

    Function TotalTaxed(_runningTotal As Decimal) As Decimal
        Static _totalTaxed As Decimal
        _totalTaxed = CDec(_runningTotal * 0.06)
        Return  _totalTaxed
    End Function

End Module
