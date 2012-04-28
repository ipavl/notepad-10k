Public Class InsertTimeDate

    Private Hours, Minutes, Seconds, Hourin24, TimeZone, Month, Day, Year, Numerical, TwoDigitYear As Boolean

    Public Save As Boolean = False

    Private Function UpdateSample()

        Return Nothing
    End Function

    Private Sub InsertTimeDate_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        chkHours.Checked = True
        chkMins.Checked = True
        chkSec.Checked = True
        chkMonth.Checked = True
        chkDay.Checked = True
        chkYear.Checked = True
        chkNumMonth.Checked = True
    End Sub

    Private Sub chkHours_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkHours.CheckedChanged
        If Hours = False Then
            Hours = True
            chk24hour.Enabled = True
        Else
            Hours = False
            chk24hour.Enabled = True
        End If
    End Sub

    Private Sub chkMins_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMins.CheckedChanged
        If Minutes = False Then
            Minutes = True
        Else
            Minutes = False
        End If
    End Sub

End Class