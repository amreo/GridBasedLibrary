Imports GridBasedLibrary
Public Class HScaleRB

    Dim FixLocated As IMovable

    Const SIDE As Integer = 16
    Const GRID_WIDTH As Integer = 32
    Const GRID_HEIGHT As Integer = 32
    Dim G As Graphics
    Dim tilemodel As Dictionary(Of String, HSTile)
    Dim map As HSMapClientWithScreen
    Dim startPoint As ILocated
    Dim endPoint As ILocated

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Me.Focus()
        G = DrawPanel.CreateGraphics()
        G.Clear(Color.CornflowerBlue)

        tilemodel = New Dictionary(Of String, HSTile)()
        tilemodel.Add("floor", New HSTile("floor"))
        tilemodel.Add("wall", New Wall())
        tilemodel.Add("water", New HSTile("water"))
        For Each item As KeyValuePair(Of String, HSTile) In tilemodel
            TileLB.Items.Add(item.Key)
        Next
        TileLB.SelectedIndex = 0
        map = HSMapClientWithScreen.CreateHSMapClientWithScreen(0, 0, 64, 64, tilemodel("floor"), 16, 16, GRID_WIDTH, GRID_HEIGHT)
    End Sub

    Function createGridList() As List(Of Coord)
        Dim l As New List(Of Coord)
        For y = 0 To GRID_HEIGHT - 1
            For x = 0 To GRID_WIDTH - 1
                l.Add(New Coord(x, y))
            Next
        Next
        Return l
    End Function

    Sub DrawFull()
        For y = 0 To GRID_HEIGHT - 1
            For x = 0 To GRID_WIDTH - 1
                If map.GetTile(x + map.GetScreenX, y + map.GetScreenY) Is Nothing Then
                    G.FillRectangle(Brushes.White, x * SIDE, y * SIDE, SIDE, SIDE)
                ElseIf map.GetTile(x + map.GetScreenX, y + map.GetScreenY).IsEqual(tilemodel("floor")) Then
                    G.FillRectangle(Brushes.Lime, x * SIDE, y * SIDE, SIDE, SIDE)
                ElseIf map.GetTile(x + map.GetScreenX, y + map.GetScreenY).IsEqual(tilemodel("wall")) Then
                    G.FillRectangle(Brushes.Brown, x * SIDE, y * SIDE, SIDE, SIDE)
                ElseIf map.GetTile(x + map.GetScreenX, y + map.GetScreenY).IsEqual(tilemodel("water")) Then
                    G.FillRectangle(createBlue(), x * SIDE, y * SIDE, SIDE, SIDE)
                End If
                If Not map.GetActor(x + map.GetScreenX, y + map.GetScreenY) Is Nothing Then G.FillEllipse(Brushes.Red, x * SIDE, y * SIDE, SIDE, SIDE)


                If GridCB.Checked Then G.DrawRectangle(Pens.Black, x * SIDE, y * SIDE, SIDE, SIDE)
            Next
        Next
    End Sub

    Sub Draw()
        For Each c As Coord In map.GetRenderUpdateCoords
            c = New Coord(c.GetX + map.GetScreenX, c.GetY + map.GetScreenY)
            If map.GetTile(c) Is Nothing Then
                G.FillRectangle(Brushes.White, (c.GetX - map.GetScreenX) * SIDE, (c.GetY - map.GetScreenY) * SIDE, SIDE, SIDE)
                map.RemoveRenderFlag(c)
            ElseIf map.GetTile(c).IsEqual(tilemodel("floor")) Then
                G.FillRectangle(Brushes.Lime, (c.GetX - map.GetScreenX) * SIDE, (c.GetY - map.GetScreenY) * SIDE, SIDE, SIDE)
                map.RemoveRenderFlag(c)
            ElseIf map.GetTile(c).IsEqual(tilemodel("wall")) Then
                G.FillRectangle(Brushes.Brown, (c.GetX - map.GetScreenX) * SIDE, (c.GetY - map.GetScreenY) * SIDE, SIDE, SIDE)
                map.RemoveRenderFlag(c)
            ElseIf map.GetTile(c).IsEqual(tilemodel("water")) Then
                G.FillRectangle(createBlue(), (c.GetX - map.GetScreenX) * SIDE, (c.GetY - map.GetScreenY) * SIDE, SIDE, SIDE)
            End If
            If Not map.GetActor(c) Is Nothing Then G.FillEllipse(Brushes.Red, (c.GetX - map.GetScreenX) * SIDE, (c.GetY - map.GetScreenY) * SIDE, SIDE, SIDE)

            If GridCB.Checked Then G.DrawRectangle(Pens.Black, (c.GetX - map.GetScreenX) * SIDE, (c.GetY - map.GetScreenY) * SIDE, SIDE, SIDE)

        Next
    End Sub



    Public Function GetHeuristFunction() As ICoordDistanceFunction
        If HManatthanRB.Checked Then
            Return ManhattanDistanceFunction.DistanceFunction
        ElseIf HDiagonalRB.Checked Then
            Return DiagonalDistanceFunction.DistanceFunction
        ElseIf HEuclideanRB.Checked Then
            Return EuclideanDistanceFunction.DistanceFunction
        ElseIf HSquaredEuclideanRB.Checked Then
            Return SquaredEuclideanDistanceFunction.DistanceFunction
        Else
            Return ManhattanDistanceFunction.DistanceFunction

        End If
    End Function

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        G = DrawPanel.CreateGraphics()
        G.Clear(Color.CornflowerBlue)
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        G.Clear(Color.CornflowerBlue)
    End Sub

    Private Sub DrawPanel_MouseClick(sender As Object, e As MouseEventArgs) Handles DrawPanel.MouseClick
        Dim c As Coord = New Coord(Math.Floor(e.X / SIDE), Math.Floor(e.Y / SIDE))
        If DrawPanelEventClickLB.SelectedItem() = "SetTile" Then
            map.SetTile(c.GetX + map.GetScreenX, c.GetY + map.GetScreenY, tilemodel(TileLB.SelectedItem))
            Draw()
        ElseIf DrawPanelEventClickLB.SelectedItem() = "Spawn HSActor" Then
            Dim act As IActor = HSActor.Spawn("Userino", c.GetX + map.GetScreenX, c.GetY + map.GetScreenY, map)
            If Not act Is Nothing Then actLB.Items.Add(act)
            Draw()
        ElseIf DrawPanelEventClickLB.SelectedItem() = "Remove Actor" Then
            Dim actino As IActor = map.GetMapTile(c.GetX + map.GetScreenX, c.GetY + map.GetScreenY).GetActor
            map.DespawnActor(actino)
            actLB.Items.Remove(actino)
            Draw()
        End If
    End Sub
    Private Sub DrawPanel_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DrawPanel.MouseMove
        Dim c As Coord = New Coord(Math.Floor(e.X / SIDE), Math.Floor(e.Y / SIDE))
        TextLB.Text = "FC=" & c.ToString & " TC=" & New Coord(c.GetX() + map.GetScreenX(), c.GetY() + map.GetScreenY()).ToString & " O=" + map.GetScreenLocation.ToString
    End Sub

    Private Sub DrawPanel_MouseLeave(sender As System.Object, e As System.EventArgs) Handles DrawPanel.MouseLeave
        TextLB.Text = "C=(--,--)"
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        DrawFull()
    End Sub

    Private Sub GridCB_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles GridCB.CheckedChanged
        DrawFull()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub AddCB_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub InfoStrCB_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub DrawPanel_Paint(sender As Object, e As PaintEventArgs) Handles DrawPanel.Paint

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Draw()
    End Sub
    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        FixLocated = map
        Label1.Text = "FISSATO"
        Label1.BackColor = Color.Lime
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If FixLocated Is Nothing Then
            MsgBox("Non è stato fixato alcun oggetto", MsgBoxStyle.Critical)
            Return
        Else
            FixLocated.MoveLeftUp(NumericUpDown1.Value)
            Draw()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If FixLocated Is Nothing Then
            MsgBox("Non è stato fixato alcun oggetto", MsgBoxStyle.Critical)
            Return
        Else
            FixLocated.MoveUp(NumericUpDown1.Value)
            Draw()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If FixLocated Is Nothing Then
            MsgBox("Non è stato fixato alcun oggetto", MsgBoxStyle.Critical)
            Return
        Else
            FixLocated.MoveRightUp(NumericUpDown1.Value)
            Draw()
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If FixLocated Is Nothing Then
            MsgBox("Non è stato fixato alcun oggetto", MsgBoxStyle.Critical)
            Return
        Else
            FixLocated.MoveRight(NumericUpDown1.Value)
            Draw()
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If FixLocated Is Nothing Then
            MsgBox("Non è stato fixato alcun oggetto", MsgBoxStyle.Critical)
            Return
        Else
            FixLocated.MoveRightDown(NumericUpDown1.Value)
            Draw()
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If FixLocated Is Nothing Then
            MsgBox("Non è stato fixato alcun oggetto", MsgBoxStyle.Critical)
            Return
        Else
            FixLocated.MoveDown(NumericUpDown1.Value)
            Draw()
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If FixLocated Is Nothing Then
            MsgBox("Non è stato fixato alcun oggetto", MsgBoxStyle.Critical)
            Return
        Else
            FixLocated.MoveLeftDown(NumericUpDown1.Value)
            Draw()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If FixLocated Is Nothing Then
            MsgBox("Non è stato fixato alcun oggetto", MsgBoxStyle.Critical)
            Return
        Else
            FixLocated.MoveLeft(NumericUpDown1.Value)
            Draw()
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If FixLocated Is Nothing Then
            MsgBox("Non è stato fixato alcun oggetto", MsgBoxStyle.Critical)
            Return
        Else
            Try
                Dim x, y As Integer
                x = InputBox("inserire deltaX")
                y = InputBox("inserire deltaY")
                FixLocated.MoveByOffset(x, y)
                DrawFull()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim mm As mazeMode = mazeMode.CLEAN
        If Button24.BackColor = Color.Red Then mm = mm Or mazeMode.LEFT_UP
        If Button23.BackColor = Color.Red Then mm = mm Or mazeMode.UP
        If Button22.BackColor = Color.Red Then mm = mm Or mazeMode.RIGHT_UP
        If Button21.BackColor = Color.Red Then mm = mm Or mazeMode.LEFT
        If Button19.BackColor = Color.Red Then mm = mm Or mazeMode.RIGHT
        If Button18.BackColor = Color.Red Then mm = mm Or mazeMode.LEFT_DOWN
        If Button17.BackColor = Color.Red Then mm = mm Or mazeMode.DOWN
        If Button16.BackColor = Color.Red Then mm = mm Or mazeMode.RIGHT_DOWN
        Dim m As New MazeGenerator(New MSRandomGenerator(), tilemodel("floor"), tilemodel("wall"), mm)
        m.Generate(map)
        Draw()
    End Sub

    
    Private Sub Button21_Click(sender As Button, e As EventArgs) Handles Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click
        If sender.BackColor = Color.White Then
            sender.BackColor = Color.Red
        Else
            sender.BackColor = Color.White
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If actLB.SelectedItem Is Nothing Then Return
        Dim actino As IActor = actLB.SelectedItem
        map.DespawnActor(actino)
        actLB.Items.Remove(actino)
        Draw()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If actLB.SelectedItem Is Nothing Then Return
        FixLocated = actLB.SelectedItem
        Label1.Text = "FISSATO"
        Label1.BackColor = Color.Lime
    End Sub

    Function createBlue() As SolidBrush
        Dim r As Integer, g As Integer, b As Integer
        r = Color.Blue.R
        g = Color.Blue.G
        b = Color.Blue.B
        If ttt <= 20 Then
            r += ttt * 5
            g += ttt * 5
        Else
            r += (40 - ttt) * 5
            g += (40 - ttt) * 5
        End If
        Return New SolidBrush(Color.FromArgb(r, g, b))
    End Function

    Dim ttt As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Draw()
        ttt += 1
        If ttt = 40 Then ttt = 0
    End Sub
    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Timer1.Start()
        Else
            Timer1.Stop()
        End If
    End Sub

    Private Sub GroupBox7_Enter(sender As Object, e As EventArgs) Handles GroupBox7.Enter

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub
    WithEvents finder As AStarPathFinder
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim h As ICoordDistanceFunction
        'verifica ogni heurista
        If HManatthanRB.Checked Then
            h = ManhattanDistanceFunction.DistanceFunction
        ElseIf HDiagonalRB.Checked Then
            h = DiagonalDistanceFunction.DistanceFunction
        ElseIf HEuclideanRB.Checked Then
            h = EuclideanDistanceFunction.DistanceFunction
        ElseIf HNullRB.Checked Then
            h = NullDistanceFunction.DistanceFunction
        Else
            h = SquaredEuclideanDistanceFunction.DistanceFunction
        End If
        Dim mm As ActorDirections
        If Button24.BackColor = Color.Red Then mm = mm Or ActorDirections.LEFT_UP
        If Button23.BackColor = Color.Red Then mm = mm Or ActorDirections.UP
        If Button22.BackColor = Color.Red Then mm = mm Or ActorDirections.RIGHT_UP
        If Button21.BackColor = Color.Red Then mm = mm Or ActorDirections.LEFT
        If Button19.BackColor = Color.Red Then mm = mm Or ActorDirections.RIGHT
        If Button18.BackColor = Color.Red Then mm = mm Or ActorDirections.LEFT_DOWN
        If Button17.BackColor = Color.Red Then mm = mm Or ActorDirections.DOWN
        If Button16.BackColor = Color.Red Then mm = mm Or ActorDirections.RIGHT_DOWN
        finder = New AStarPathFinder(mm, h, HScaleNUD.Value)
        Dim path As LinkedList(Of Coord) = finder.Find(map.GetActor(startPoint), startPoint, endPoint, map)

        If Not path Is Nothing Then
            ' DrawFull()
            For Each c As Coord In path
                G.FillRectangle(New SolidBrush(Color.FromArgb(128, Color.Beige)), (c.GetX - map.GetScreenX) * SIDE, (c.GetY - map.GetScreenY) * SIDE, SIDE, SIDE)
            Next
        Else
            MsgBox("Percorso 404")
        End If
    End Sub

    Private Sub ImpostaComeStartPointToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpostaComeStartPointToolStripMenuItem.Click
        If actLB.SelectedItem Is Nothing Then Return
        startPoint = actLB.SelectedItem
        G.FillRectangle(New SolidBrush(Color.FromArgb(128, Color.Green)), (startPoint.GetX - map.GetScreenX) * SIDE, (startPoint.GetY - map.GetScreenY) * SIDE, SIDE, SIDE)
    End Sub

    Private Sub ImpostaComeEndPointToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpostaComeEndPointToolStripMenuItem.Click
        If actLB.SelectedItem Is Nothing Then Return
        endPoint = actLB.SelectedItem
        G.FillRectangle(New SolidBrush(Color.FromArgb(128, Color.Red)), (endPoint.GetX - map.GetScreenX) * SIDE, (endPoint.GetY - map.GetScreenY) * SIDE, SIDE, SIDE)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim h As ICoordDistanceFunction
        'verifica ogni heurista
        If HManatthanRB.Checked Then
            h = ManhattanDistanceFunction.DistanceFunction
        ElseIf HDiagonalRB.Checked Then
            h = DiagonalDistanceFunction.DistanceFunction
        ElseIf HEuclideanRB.Checked Then
            h = EuclideanDistanceFunction.DistanceFunction
        ElseIf HNullRB.Checked Then
            h = NullDistanceFunction.DistanceFunction
        Else
            h = SquaredEuclideanDistanceFunction.DistanceFunction
        End If
        MsgBox(h.GetDistance(startPoint, endPoint, HScaleNUD.Value))

    End Sub
    Dim o1 As Integer = 0
    Sub iii(c As Coord)
        G.FillRectangle(New SolidBrush(Color.FromArgb(128, Color.CornflowerBlue)), (c.GetX - map.GetScreenX) * SIDE, (c.GetY - map.GetScreenY) * SIDE, SIDE, SIDE)
        o1 += 1
    End Sub
    Dim c1 As Integer = 0
    Sub iii2(c As Coord)
        G.FillRectangle(New SolidBrush(Color.FromArgb(128, Color.Yellow)), (c.GetX - map.GetScreenX) * SIDE, (c.GetY - map.GetScreenY) * SIDE, SIDE, SIDE)
        c1 += 1
    End Sub
End Class
