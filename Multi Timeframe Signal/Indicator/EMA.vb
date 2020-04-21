Imports System.Threading

Namespace Indicator
    Public Module EMA
        Dim cts As CancellationTokenSource
        Public Sub CalculateEMA(ByVal emaPeriod As Integer, ByVal inputPayload As Dictionary(Of Date, Payload), ByRef outputPayload As Dictionary(Of Date, Decimal))
            If inputPayload IsNot Nothing AndAlso inputPayload.Count > 0 Then
                Dim finalPriceToBeAdded As Decimal = 0
                For Each runningInputPayload In inputPayload
                    'If it is less than IndicatorPeriod, we will need to take SMA of all previous prices, hence the call to GetSubPayload
                    Dim previousNInputFieldPayload As List(Of KeyValuePair(Of DateTime, Payload)) = Common.GetSubPayload(inputPayload,
                                                                                                                           runningInputPayload.Key,
                                                                                                                            emaPeriod,
                                                                                                                            False)
                    If previousNInputFieldPayload Is Nothing Then
                        finalPriceToBeAdded += runningInputPayload.Value.Close
                    ElseIf previousNInputFieldPayload IsNot Nothing AndAlso previousNInputFieldPayload.Count <= emaPeriod - 1 Then 'Because the first field is handled outside
                        Dim totalOfAllPrices As Decimal = 0
                        totalOfAllPrices = runningInputPayload.Value.Close
                        totalOfAllPrices += previousNInputFieldPayload.Sum(Function(s) s.Value.Close)
                        finalPriceToBeAdded = totalOfAllPrices / (previousNInputFieldPayload.Count + 1)
                    Else
                        Dim previousInputFieldData = Common.GetPayloadAtPositionOrPositionMinus1(runningInputPayload.Key, outputPayload)
                        If previousInputFieldData.Key <> DateTime.MinValue Then
                            Dim previousInputFieldValue As Decimal = previousInputFieldData.Value
                            finalPriceToBeAdded = (runningInputPayload.Value.Close * (2 / (1 + emaPeriod))) + (previousInputFieldValue * (1 - (2 / (emaPeriod + 1))))
                        End If
                    End If
                    If outputPayload Is Nothing Then outputPayload = New Dictionary(Of Date, Decimal)
                    outputPayload.Add(runningInputPayload.Key, finalPriceToBeAdded)
                Next
            End If
        End Sub
    End Module
End Namespace
