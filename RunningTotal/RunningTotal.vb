Option Strict On
Option Explicit On
Option Compare Text
'TODO 
'[x] keep track of transactions in a function called RunningTotal()
'[x] get the current total as needed
'[ ] provide a way to clear/zero the total
'[ ] display transactions and running total formatted as currency
'[ ] super bounus: create a method to include sales tax to the transaction
Module RunningTotal

    Sub Main()
        Dim userInput As String
        Dim quit As Boolean = False
        Dim purchaceAmount As Decimal
        Do
            userInput = Console.ReadLine
            If userInput <> "Q" Then
                Try
                    purchaceAmount = CDec(userInput)
                    Console.WriteLine(RunningTotal(purchaceAmount))
                Catch ex As Exception
                    Console.WriteLine("Not a valid number")
                End Try
            ElseIf userInput = "Q" Then
                quit = True
            End If
        Loop Until quit = True

        Console.Clear()
        Console.WriteLine($"The total is: {RunningTotal(0)}")
        Console.WriteLine("Have a nice day!")
    End Sub

    Function RunningTotal(currentNumber As Decimal) As Decimal
        Static _runningTotal As Decimal
        _runningTotal += currentNumber
        Return _runningTotal
    End Function

End Module
