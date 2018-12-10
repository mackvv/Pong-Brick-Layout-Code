Public Class Start

    Private Sub button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click, btnAbout.Click, btnStart.Click
        Select Case sender.tag
            Case 1
                Help.Show()
            Case 2
                About.Show()
            Case 3
                AtariGame.Show()
        End Select

        Me.Hide()
    End Sub

    
End Class
