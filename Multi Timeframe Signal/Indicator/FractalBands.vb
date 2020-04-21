Namespace Indicator
    Public Module FractalBands
        Public Sub CalculateFractal(ByVal inputPayload As Dictionary(Of Date, Payload), ByRef outputHighPayload As Dictionary(Of Date, Decimal), ByRef outputLowPayload As Dictionary(Of Date, Decimal))
            If inputPayload IsNot Nothing AndAlso inputPayload.Count > 0 Then
                Dim highFractal As Decimal = 0
                Dim lowFractal As Decimal = 0
                For Each runningPayload In inputPayload.Keys
                    If inputPayload(runningPayload).PreviousPayload IsNot Nothing AndAlso
                        inputPayload(runningPayload).PreviousPayload.PreviousPayload IsNot Nothing Then
                        If inputPayload(runningPayload).PreviousPayload.High < inputPayload(runningPayload).PreviousPayload.PreviousPayload.High AndAlso
                            inputPayload(runningPayload).High < inputPayload(runningPayload).PreviousPayload.PreviousPayload.High Then
                            If IsFractalHighSatisfied(inputPayload(runningPayload).PreviousPayload.PreviousPayload, False) Then
                                highFractal = inputPayload(runningPayload).PreviousPayload.PreviousPayload.High
                            End If
                        End If
                        If inputPayload(runningPayload).PreviousPayload.Low > inputPayload(runningPayload).PreviousPayload.PreviousPayload.Low AndAlso
                            inputPayload(runningPayload).Low > inputPayload(runningPayload).PreviousPayload.PreviousPayload.Low Then
                            If IsFractalLowSatisfied(inputPayload(runningPayload).PreviousPayload.PreviousPayload, False) Then
                                lowFractal = inputPayload(runningPayload).PreviousPayload.PreviousPayload.Low
                            End If
                        End If
                    End If
                    If outputHighPayload Is Nothing Then outputHighPayload = New Dictionary(Of Date, Decimal)
                    outputHighPayload.Add(runningPayload, highFractal)
                    If outputLowPayload Is Nothing Then outputLowPayload = New Dictionary(Of Date, Decimal)
                    outputLowPayload.Add(runningPayload, lowFractal)
                Next
            End If
        End Sub
        Private Function IsFractalHighSatisfied(ByVal candidateCandle As Payload, ByVal checkOnlyPrevious As Boolean) As Boolean
            Dim ret As Boolean = False
            If candidateCandle IsNot Nothing AndAlso
                candidateCandle.PreviousPayload IsNot Nothing AndAlso
                candidateCandle.PreviousPayload.PreviousPayload IsNot Nothing Then
                If checkOnlyPrevious AndAlso candidateCandle.PreviousPayload.High < candidateCandle.High Then
                    ret = True
                ElseIf candidateCandle.PreviousPayload.High < candidateCandle.High AndAlso
                        candidateCandle.PreviousPayload.PreviousPayload.High < candidateCandle.High Then
                    ret = True
                ElseIf candidateCandle.PreviousPayload.High = candidateCandle.High Then
                    ret = IsFractalHighSatisfied(candidateCandle.PreviousPayload, checkOnlyPrevious)
                ElseIf candidateCandle.PreviousPayload.High > candidateCandle.High Then
                    ret = False
                ElseIf candidateCandle.PreviousPayload.PreviousPayload.High = candidateCandle.High Then
                    ret = IsFractalHighSatisfied(candidateCandle.PreviousPayload.PreviousPayload, True)
                ElseIf candidateCandle.PreviousPayload.PreviousPayload.High > candidateCandle.High Then
                    ret = False
                End If
            End If
            Return ret
        End Function
        Private Function IsFractalLowSatisfied(ByVal candidateCandle As Payload, ByVal checkOnlyPrevious As Boolean) As Boolean
            Dim ret As Boolean = False
            If candidateCandle IsNot Nothing AndAlso
                candidateCandle.PreviousPayload IsNot Nothing AndAlso
                candidateCandle.PreviousPayload.PreviousPayload IsNot Nothing Then
                If checkOnlyPrevious AndAlso candidateCandle.PreviousPayload.Low > candidateCandle.Low Then
                    ret = True
                ElseIf candidateCandle.PreviousPayload.Low > candidateCandle.Low AndAlso
                        candidateCandle.PreviousPayload.PreviousPayload.Low > candidateCandle.Low Then
                    ret = True
                ElseIf candidateCandle.PreviousPayload.Low = candidateCandle.Low Then
                    ret = IsFractalLowSatisfied(candidateCandle.PreviousPayload, checkOnlyPrevious)
                ElseIf candidateCandle.PreviousPayload.Low < candidateCandle.Low Then
                    ret = False
                ElseIf candidateCandle.PreviousPayload.PreviousPayload.Low = candidateCandle.Low Then
                    ret = IsFractalLowSatisfied(candidateCandle.PreviousPayload.PreviousPayload, True)
                ElseIf candidateCandle.PreviousPayload.PreviousPayload.Low < candidateCandle.Low Then
                    ret = False
                End If
            End If
            Return ret
        End Function
    End Module
End Namespace
