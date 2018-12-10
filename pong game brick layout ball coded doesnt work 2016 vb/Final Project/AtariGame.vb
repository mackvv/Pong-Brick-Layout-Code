Public Class AtariGame
    Public points As Integer
    Public lives As Integer = 5
    Dim start As Integer
    Dim finish As Integer
    Sub startRound()
        For i = 1 To 105
            Me.Controls("brick" & i).Visible = False
        Next

        Dim numOfRows As Integer
        numOfRows = RndInt(5, 1)


        Select Case numOfRows
            Case 1
                Call createbricks(22, 42)

                start = 22
                finish = 42
            Case 2
                Call createbricks(22, 42)
                Call createbricks(43, 63)

                start = 22
                finish = 63
            Case 3
                Call createbricks(22, 42)
                Call createbricks(43, 63)
                Call createbricks(64, 84)

                start = 22
                finish = 84
            Case 4
                Call createbricks(1, 21)
                Call createbricks(22, 42)
                Call createbricks(43, 63)
                Call createbricks(64, 84)

                start = 1
                finish = 84
            Case 5
                Call createbricks(1, 21)
                Call createbricks(22, 42)
                Call createbricks(43, 63)
                Call createbricks(64, 84)
                Call createbricks(85, 105)

                start = 1
                finish = 105
        End Select


        Call chooseColour(start, finish)

        ball.Location = New Point(733, 344)

    End Sub


    Sub createbricks(ByVal brickNumStart As Integer, ByVal brickNumEnd As Integer)
        For i = brickNumStart To brickNumEnd
            Me.Controls("brick" & i).Visible = True
        Next

        Static lastRow As Integer

        Dim brickNum As Integer = brickNumStart



        Dim yPlace As Integer
        yPlace = Me.Controls("brick" & brickNumStart).Top



        Dim bricks2TakeAway As Integer

        Do
            bricks2TakeAway = RndInt(12, 0)
        Loop Until bricks2TakeAway <> lastRow



        For brickNum = brickNumStart To brickNumEnd
            If bricks2TakeAway = 0 Then
                layoutBricks(21, 22, brickNum, yPlace)

            Else
                Select Case brickNum
                    Case brickNumStart To (brickNumStart + bricks2TakeAway - 1)
                        Me.Controls("brick" & brickNum).Visible = False
                    Case Else
                        layoutBricks((21 - bricks2TakeAway), (21 - bricks2TakeAway + 1), brickNum, yPlace)
                End Select
            End If

        Next
        lastRow = bricks2TakeAway
    End Sub

    Sub layoutBricks(ByVal numOfBricks As Integer, ByVal NumSpacesBetween As Integer, ByVal brick As Integer, ByVal yplace As Integer)
        Dim space As Integer = Me.Width - 16
        Dim brickWidth As Double
        Dim brickHeight As Integer = 30
        Static xplace As Double = 10
        Dim spaceBetween As Integer = 10
        Static xFlag As Integer


        brickWidth = (space - (NumSpacesBetween * spaceBetween)) / numOfBricks
        Me.Controls("brick" & brick).Size = New Size(brickWidth, brickHeight)
        Me.Controls("brick" & brick).Location = New Point(xplace, yplace)
        xplace = xplace + brickWidth + 10

        xFlag = xFlag + 1

        If xFlag = numOfBricks Then
            xplace = 10
            xFlag = 0
        End If


    End Sub


    Function RndInt(ByVal HighNum As Integer, ByVal LowNum As Integer) As Integer
        'returns random number
        Dim randomNum As Integer

        Randomize()
        randomNum = Int((HighNum - LowNum + 1) * Rnd()) + LowNum

        Return randomNum
    End Function

    Sub chooseColour(ByVal brickNumStart As Integer, ByVal brickNumEnd As Integer)
        Static levels As Integer
        Dim randomColourSet As Integer
        Dim lastColourSet As Integer

        Do
            randomColourSet = RndInt(9, 1)
        Loop Until randomColourSet <> lastColourSet
        lastColourSet = randomColourSet

        levels = levels + 1

        If levels Mod 5 = 0 Then
            randomColourSet = 10
        End If

        Select Case randomColourSet
            Case Is = 1
                Call purple(brickNumStart, brickNumEnd)
            Case Is = 2
                Call red(brickNumStart, brickNumEnd)
            Case Is = 3
                Call yellow(brickNumStart, brickNumEnd)
            Case Is = 4
                Call darkBlue(brickNumStart, brickNumEnd)
            Case Is = 5
                Call brightBlue(brickNumStart, brickNumEnd)
            Case Is = 6
                Call pink(brickNumStart, brickNumEnd)
            Case Is = 7
                Call darkGreen(brickNumStart, brickNumEnd)
            Case Is = 8
                Call brightGreen(brickNumStart, brickNumEnd)
            Case Is = 9
                Call gray(brickNumStart, brickNumEnd)
            Case Is = 10
                Call multiColour(brickNumStart, brickNumEnd)
        End Select

    End Sub


    Sub purple(ByVal brickNumStart As Integer, ByVal brickNumEnd As Integer)
        Dim brickNum As Integer
        Dim lastColour As Integer
        For brickNum = brickNumStart To brickNumEnd
            Dim randomColour As Integer
            Dim chosenColour As Color

            Do
                randomColour = RndInt(10, 1)
            Loop Until randomColour <> lastColour


            Select Case randomColour
                Case Is = 1
                    chosenColour = Color.Violet
                Case Is = 2
                    chosenColour = Color.Thistle
                Case Is = 3
                    chosenColour = Color.SlateBlue
                Case Is = 4
                    chosenColour = Color.Purple
                Case Is = 5
                    chosenColour = Color.Plum
                Case Is = 6
                    chosenColour = Color.Indigo
                Case Is = 7
                    chosenColour = Color.Orchid
                Case Is = 8
                    chosenColour = Color.MediumPurple
                Case Is = 9
                    chosenColour = Color.DarkViolet
                Case Is = 10
                    chosenColour = Color.BlueViolet
            End Select

            Me.Controls("brick" & brickNum).BackColor = chosenColour
            lastColour = randomColour
        Next
    End Sub

    Sub red(ByVal brickNumStart As Integer, ByVal brickNumEnd As Integer)
        Dim brickNum As Integer
        Dim lastColour As Integer
        For brickNum = brickNumStart To brickNumEnd
            Dim randomColour As Integer
            Dim chosenColour As Color

            Do
                randomColour = RndInt(10, 1)
            Loop Until randomColour <> lastColour

            Select Case randomColour
                Case Is = 1
                    chosenColour = Color.Crimson
                Case Is = 2
                    chosenColour = Color.DarkRed
                Case Is = 3
                    chosenColour = Color.Firebrick
                Case Is = 4
                    chosenColour = Color.Maroon
                Case Is = 5
                    chosenColour = Color.Red
                Case Is = 6
                    chosenColour = Color.Tomato
                Case Is = 7
                    chosenColour = Color.OrangeRed
                Case Is = 8
                    chosenColour = Color.IndianRed
                Case Is = 9
                    chosenColour = Color.Salmon
                Case Is = 10
                    chosenColour = Color.Sienna
            End Select

            Me.Controls("brick" & brickNum).BackColor = chosenColour
            lastColour = randomColour
        Next
    End Sub

    Sub yellow(ByVal brickNumStart As Integer, ByVal brickNumEnd As Integer)
        Dim brickNum As Integer
        Dim lastColour As Integer
        For brickNum = brickNumStart To brickNumEnd
            Dim randomColour As Integer
            Dim chosenColour As Color

            Do
                randomColour = RndInt(10, 1)
            Loop Until randomColour <> lastColour

            Select Case randomColour
                Case Is = 1
                    chosenColour = Color.DarkOrange
                Case Is = 2
                    chosenColour = Color.Gold
                Case Is = 3
                    chosenColour = Color.Goldenrod
                Case Is = 4
                    chosenColour = Color.Khaki
                Case Is = 5
                    chosenColour = Color.LemonChiffon
                Case Is = 6
                    chosenColour = Color.Orange
                Case Is = 7
                    chosenColour = Color.Yellow
                Case Is = 8
                    chosenColour = Color.DarkGoldenrod
                Case Is = 9
                    chosenColour = Color.DarkKhaki
                Case Is = 10
                    chosenColour = Color.SandyBrown
            End Select

            Me.Controls("brick" & brickNum).BackColor = chosenColour
            lastColour = randomColour
        Next
    End Sub

    Sub darkBlue(ByVal brickNumStart As Integer, ByVal brickNumEnd As Integer)
        Dim brickNum As Integer
        Dim lastColour As Integer
        For brickNum = brickNumStart To brickNumEnd
            Dim randomColour As Integer
            Dim chosenColour As Color

            Do
                randomColour = RndInt(10, 1)
            Loop Until randomColour <> lastColour

            Select Case randomColour
                Case Is = 1
                    chosenColour = Color.Blue
                Case Is = 2
                    chosenColour = Color.DarkBlue
                Case Is = 3
                    chosenColour = Color.DodgerBlue
                Case Is = 4
                    chosenColour = Color.MediumBlue
                Case Is = 5
                    chosenColour = Color.MidnightBlue
                Case Is = 6
                    chosenColour = Color.Navy
                Case Is = 7
                    chosenColour = Color.RoyalBlue
                Case Is = 8
                    chosenColour = Color.SteelBlue
                Case Is = 9
                    chosenColour = Color.DarkSlateBlue
                Case Is = 10
                    chosenColour = Color.DarkCyan
            End Select

            Me.Controls("brick" & brickNum).BackColor = chosenColour
            lastColour = randomColour
        Next
    End Sub

    Sub brightBlue(ByVal brickNumStart As Integer, ByVal brickNumEnd As Integer)
        Dim brickNum As Integer
        Dim lastColour As Integer
        For brickNum = brickNumStart To brickNumEnd
            Dim randomColour As Integer
            Dim chosenColour As Color

            Do
                randomColour = RndInt(10, 1)
            Loop Until randomColour <> lastColour

            Select Case randomColour
                Case Is = 1
                    chosenColour = Color.Aqua
                Case Is = 2
                    chosenColour = Color.Aquamarine
                Case Is = 3
                    chosenColour = Color.Cyan
                Case Is = 4
                    chosenColour = Color.PaleTurquoise
                Case Is = 5
                    chosenColour = Color.DeepSkyBlue
                Case Is = 6
                    chosenColour = Color.LightSeaGreen
                Case Is = 7
                    chosenColour = Color.LightBlue
                Case Is = 8
                    chosenColour = Color.LightSkyBlue
                Case Is = 9
                    chosenColour = Color.SkyBlue
                Case Is = 10
                    chosenColour = Color.RoyalBlue
            End Select

            Me.Controls("brick" & brickNum).BackColor = chosenColour
            lastColour = randomColour
        Next
    End Sub

    Sub pink(ByVal brickNumStart As Integer, ByVal brickNumEnd As Integer)
        Dim brickNum As Integer
        Dim lastColour As Integer
        For brickNum = brickNumStart To brickNumEnd
            Dim randomColour As Integer
            Dim chosenColour As Color

            Do
                randomColour = RndInt(10, 1)
            Loop Until randomColour <> lastColour

            Select Case randomColour
                Case Is = 1
                    chosenColour = Color.Crimson
                Case Is = 2
                    chosenColour = Color.DarkSalmon
                Case Is = 3
                    chosenColour = Color.DeepPink
                Case Is = 4
                    chosenColour = Color.Fuchsia
                Case Is = 5
                    chosenColour = Color.LightCoral
                Case Is = 6
                    chosenColour = Color.HotPink
                Case Is = 7
                    chosenColour = Color.Coral
                Case Is = 8
                    chosenColour = Color.LightPink
                Case Is = 9
                    chosenColour = Color.Pink
                Case Is = 10
                    chosenColour = Color.Magenta
            End Select

            Me.Controls("brick" & brickNum).BackColor = chosenColour
            lastColour = randomColour
        Next
    End Sub

    Sub darkGreen(ByVal brickNumStart As Integer, ByVal brickNumEnd As Integer)
        Dim brickNum As Integer
        Dim lastColour As Integer
        For brickNum = brickNumStart To brickNumEnd
            Dim randomColour As Integer
            Dim chosenColour As Color

            Do
                randomColour = RndInt(10, 1)
            Loop Until randomColour <> lastColour

            Select Case randomColour
                Case Is = 1
                    chosenColour = Color.DarkGreen
                Case Is = 2
                    chosenColour = Color.DarkOliveGreen
                Case Is = 3
                    chosenColour = Color.DarkSeaGreen
                Case Is = 4
                    chosenColour = Color.ForestGreen
                Case Is = 5
                    chosenColour = Color.Green
                Case Is = 6
                    chosenColour = Color.Olive
                Case Is = 7
                    chosenColour = Color.OliveDrab
                Case Is = 8
                    chosenColour = Color.SeaGreen
                Case Is = 9
                    chosenColour = Color.MediumSeaGreen
                Case Is = 10
                    chosenColour = Color.LimeGreen
            End Select

            Me.Controls("brick" & brickNum).BackColor = chosenColour
            lastColour = randomColour
        Next
    End Sub

    Sub brightGreen(ByVal brickNumStart As Integer, ByVal brickNumEnd As Integer)
        Dim brickNum As Integer
        Dim lastColour As Integer
        For brickNum = brickNumStart To brickNumEnd
            Dim randomColour As Integer
            Dim chosenColour As Color

            Do
                randomColour = RndInt(10, 1)
            Loop Until randomColour <> lastColour

            Select Case randomColour
                Case Is = 1
                    chosenColour = Color.Chartreuse
                Case Is = 2
                    chosenColour = Color.GreenYellow
                Case Is = 3
                    chosenColour = Color.Green
                Case Is = 4
                    chosenColour = Color.LawnGreen
                Case Is = 5
                    chosenColour = Color.LightGreen
                Case Is = 6
                    chosenColour = Color.LightSeaGreen
                Case Is = 7
                    chosenColour = Color.Lime
                Case Is = 8
                    chosenColour = Color.YellowGreen
                Case Is = 9
                    chosenColour = Color.SpringGreen
                Case Is = 10
                    chosenColour = Color.PaleGreen
            End Select

            Me.Controls("brick" & brickNum).BackColor = chosenColour
            lastColour = randomColour
        Next
    End Sub

    Sub gray(ByVal brickNumStart As Integer, ByVal brickNumEnd As Integer)
        Dim brickNum As Integer
        Dim lastColour As Integer
        For brickNum = brickNumStart To brickNumEnd
            Dim randomColour As Integer
            Dim chosenColour As Color

            Do
                randomColour = RndInt(10, 1)
            Loop Until randomColour <> lastColour

            Select Case randomColour
                Case Is = 1
                    chosenColour = Color.DarkGray
                Case Is = 2
                    chosenColour = Color.DarkSlateGray
                Case Is = 3
                    chosenColour = Color.DimGray
                Case Is = 4
                    chosenColour = Color.Gainsboro
                Case Is = 5
                    chosenColour = Color.LightGray
                Case Is = 6
                    chosenColour = Color.LightSlateGray
                Case Is = 7
                    chosenColour = Color.OldLace
                Case Is = 8
                    chosenColour = Color.Silver
                Case Is = 9
                    chosenColour = Color.SlateGray
                Case Is = 10
                    chosenColour = Color.WhiteSmoke
            End Select

            Me.Controls("brick" & brickNum).BackColor = chosenColour
            lastColour = randomColour
        Next
    End Sub

    Sub multiColour(ByVal brickNumStart As Integer, ByVal brickNumEnd As Integer)
        Dim brickNum As Integer
        Dim lastColour As Integer
        For brickNum = brickNumStart To brickNumEnd
            Dim randomColour As Integer
            Dim chosenColour As Color

            Do
                randomColour = RndInt(7, 1)
            Loop Until randomColour <> lastColour

            Select Case randomColour
                Case Is = 1
                    chosenColour = Color.DarkOrchid
                Case Is = 2
                    chosenColour = Color.Red
                Case Is = 3
                    chosenColour = Color.Yellow
                Case Is = 4
                    chosenColour = Color.Orange
                Case Is = 5
                    chosenColour = Color.HotPink
                Case Is = 6
                    chosenColour = Color.SpringGreen
                Case Is = 7
                    chosenColour = Color.LightSkyBlue
            End Select

            Me.Controls("brick" & brickNum).BackColor = chosenColour
            lastColour = randomColour
        Next
    End Sub
    Private Sub movebar(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

            Select Case e.KeyCode
                Case Keys.Left
                If Me.bar.Bounds.IntersectsWith(Me.wallLeft.Bounds) Then
                Else
                    Me.bar.Left -= 25

                End If
                Case Keys.Right
                If Me.bar.Bounds.IntersectsWith(Me.wallRight.Bounds) Then
                Else
                    Me.bar.Left += 25
                End If
            End Select




    End Sub


    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

        If Me.bar.Bounds.IntersectsWith(Me.wallLeft.Bounds) Then
        Else
            If e.X < bar.Location.X + bar.Width / 2 Then
                Me.bar.Left -= 1
            End If
        End If

        If Me.bar.Bounds.IntersectsWith(Me.wallRight.Bounds) Then
        Else
            If e.X > bar.Location.X + bar.Width / 2 Then
                Me.bar.Left += 1
            End If
        End If



        

        




    End Sub




   
    Private Sub tmrBallMovement_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)




        Static endGame As Integer

        Static LRdirection As Integer
        Dim left As Integer = 1
        Dim right As Integer = 2

        Static UDdirection As Integer
        Dim up As Integer = 1
        Dim down As Integer = 2

        Dim xBar As Double
        Dim xBall As Double
        Dim xBox As Double

        Dim yBall As Integer
        Dim yBox As Integer
        Dim ybar As Integer

        Static ballAngle As Double


        If ball.Bounds.IntersectsWith(wallLeft.Bounds) Then
            LRdirection = right
        End If

        If ball.Bounds.IntersectsWith(wallRight.Bounds) Then
            LRdirection = left
        End If

        If ball.Bounds.IntersectsWith(wallTop.Bounds) Then
            UDdirection = down
        End If

        If ball.Bounds.IntersectsWith(wallBottom.Bounds) Then
            ball.Location = New Point(733, 344)
            UDdirection = up
            If lives = 0 Then
                tmrBallMovement.Enabled = False
                MessageBox.Show("game over")
            End If
            lives = lives - 1
        End If

        For index = start To finish
            If Me.Controls("brick" & index).Visible = True Then
                If ball.Bounds.IntersectsWith(Me.Controls("brick" & index).Bounds) Then
                    Me.Controls("brick" & index).Visible = False
                    yBall = ball.Location.Y
                    yBox = Me.Controls("brick" & index).Location.Y - Me.Controls("brick" & index).Height / 2
                    xBox = Me.Controls("brick" & index).Location.X
                    xBall = Me.Controls("brick" & index).Location.X

                    'figure out if box was hit from top or bottom 
                    If yBall <= yBox Then
                        UDdirection = up
                    Else
                        UDdirection = down
                    End If

                    Select Case index
                        Case 1 To 21
                            points = points + 20
                        Case 22 To 42
                            points = points + 15
                        Case 43 To 63
                            points = points + 10
                        Case 64 To 84
                            points = points + 5
                    End Select
                End If
            End If
        Next index

        yBall = ball.Location.Y
        ybar = bar.Location.Y - bar.Height

        If ball.Bounds.IntersectsWith(bar.Bounds) Then
            UDdirection = up
            xBar = bar.Location.X
            xBall = ball.Location.X


            Select Case xBall
                Case xBar To xBar + 45
                    LRdirection = left
                    ballAngle = 5
                    tmrBallMovement.Interval = 15
                Case xBar + 90 To xBar + 135
                    LRdirection = right
                    ballAngle = 5
                    tmrBallMovement.Interval = 15
                Case Else
                    ballAngle = 4
                    tmrBallMovement.Interval = 1
            End Select
            xBar = Nothing
            xBall = Nothing
        End If


        If ballAngle = Nothing Then
            ballAngle = 4
        End If


        Select Case LRdirection
            Case Is = right
                ball.Left += ballAngle
            Case Else
                ball.Left -= ballAngle
        End Select

        Select Case UDdirection
            Case Is = down
                ball.Top += 4
            Case Else
                ball.Top -= 4

        End Select

        For index = start To finish
            If Me.Controls("brick" & index).Visible = False Then
                endGame += 1
            End If
        Next

        If endGame = (finish - start) Then
            tmrBallMovement.Enabled = False
            MessageBox.Show("you won")
            Call startRound()
            ball.Location = New Point(733, 344)
            UDdirection = down
            LRdirection = left
            endGame = 0
            tmrBallMovement.Enabled = True
        End If

        endGame = 0

        lblLives.Text = "LIVES: " & lives
        lblPoints.Text = "POINTS: " & points


        If points = 1000 Then
            lives += 1
        End If
    End Sub

 
    Private Sub AtariGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call startRound()
    End Sub

   

    
    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        End
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        tmrBallMovement.Enabled = False
        Call restart()
        tmrBallMovement.Enabled = True
    End Sub

    Sub restart()
        points = 0
        lives = 5
        Call startRound()
    End Sub
End Class