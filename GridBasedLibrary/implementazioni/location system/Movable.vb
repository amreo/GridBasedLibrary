''' <summary>
''' Rappresenta un oggetto in grado di spostarsi
''' </summary>
''' <remarks>Rispetto a movable questa classe è centralizzata in MoveByOffset()</remarks>
Public MustInherit Class Movable
    Inherits Located
    Implements IMovable

    ''' <summary>
    ''' Sposta la cordinata in alto
    ''' </summary>
    Public Sub MoveUp() Implements IMovable.MoveUp
        'lo sposta in alto di 1
        MoveByOffset(0, -1)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in alto a destra
    ''' </summary>
    Public Sub MoveRightUp() Implements IMovable.MoveRightUp
        'lo sposta in alto a dx di 1
        MoveByOffset(1, -1)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata a destra
    ''' </summary>
    Public Sub MoveRight() Implements IMovable.MoveRight
        'lo sposta a dx di 1
        MoveByOffset(1, 0)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in basso a destra
    ''' </summary>
    Public Sub MoveRightDown() Implements IMovable.MoveRightDown
        'lo sposta in basso a dx di 1
        MoveByOffset(1, 1)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in basso
    ''' </summary>
    Public Sub MoveDown() Implements IMovable.MoveDown
        'lo sposta in basso di 1
        MoveByOffset(0, 1)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in basso a sinistra
    ''' </summary>
    Public Sub MoveLeftDown() Implements IMovable.MoveLeftDown
        'lo sposta in basso a sx di 1
        MoveByOffset(-1, 1)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata a sinistra
    ''' </summary>
    Public Sub MoveLeft() Implements IMovable.MoveLeft
        'lo sposta a sx di 1
        MoveByOffset(-1, 0)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in alto a sinistra
    ''' </summary>
    Public Sub MoveLeftUp() Implements IMovable.MoveLeftUp
        'lo sposta in basso a sx di 1
        MoveByOffset(-1, -1)
    End Sub

    ''' <summary>
    ''' Sposta la cordinata in alto
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Public Sub MoveUp(offset As Integer) Implements IMovable.MoveUp
        'lo sposta in alto di offset
        MoveByOffset(0, -offset)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in alto a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Public Sub MoveRightUp(offset As Integer) Implements IMovable.MoveRightUp
        'lo sposta in alto a dx di offset
        MoveByOffset(offset, -offset)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Public Sub MoveRight(offset As Integer) Implements IMovable.MoveRight
        'lo sposta a dx di offset
        MoveByOffset(offset, 0)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in basso a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Public Sub MoveRightDown(offset As Integer) Implements IMovable.MoveRightDown
        'lo sposta in basso a dx di offset
        MoveByOffset(offset, offset)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in basso
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Public Sub MoveDown(offset As Integer) Implements IMovable.MoveDown
        'lo sposta in basso di offset
        MoveByOffset(0, offset)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in basso a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Public Sub MoveLeftDown(offset As Integer) Implements IMovable.MoveLeftDown
        'lo sposta in basso a sx di offset 
        MoveByOffset(-offset, offset)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Public Sub MoveLeft(offset As Integer) Implements IMovable.MoveLeft
        'lo sposta a dx di offset
        MoveByOffset(-offset, 0)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in alto a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Public Sub MoveLeftUp(offset As Integer) Implements IMovable.MoveLeftUp
        'lo sposta in alto a sx di offset
        MoveByOffset(-offset, -offset)
    End Sub

    ''' <summary>
    ''' Sposta la cordinata in base alla <paramref name="direction">direzione</paramref>
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    Public Sub MoveByDirection(ByVal direction As Direction) Implements IMovable.MoveByDirection
        'sposta verso la direzione di 1
        MoveByOffset(direction.GetCoefficientX, direction.GetCoefficientY)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in base alla <paramref name="direction">direzione</paramref>
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    ''' <param name="offset">Offset</param>
    Public Sub MoveByDirection(ByVal direction As Direction, offset As Integer) Implements IMovable.MoveByDirection
        'sposta verso la direzione di 1
        MoveByOffset(direction.GetCoefficientX * offset, direction.GetCoefficientY * offset)
    End Sub

    ''' <summary>
    ''' Sposta la cordinata a destinazione
    ''' </summary>
    ''' <param name="destX">Destinazione X</param>
    ''' <param name="destY">Destinazione Y</param>
    Public Sub MoveTo(ByVal destX As Integer, destY As Integer) Implements IMovable.MoveTo
        'sposta la cordinata verso la destinazione
        MoveByOffset(destX - X, destY - Y)
    End Sub
    ''' <summary>
    ''' Sposta la cordinata a destinazione
    ''' </summary>
    ''' <param name="dest">Destinazione</param>
    Public Sub MoveTo(ByVal dest As ILocated) Implements IMovable.MoveTo
        'sposta la cordinata verso la destinazione
        MoveByOffset(dest.GetX - X, dest.GetY - Y)
    End Sub

    ''' <summary>
    ''' Sposta la cordinata in base all' offset
    ''' </summary>
    ''' <param name="offx">Offset X</param>
    ''' <param name="offy">Offset Y</param>
    Public Overridable Sub MoveByOffset(offx As Integer, offy As Integer) Implements IMovable.MoveByOffset
        'sposta la cordinata aggiungendo gli offset
        X += offx
        Y += offy
    End Sub

    ''' <summary>
    ''' Imposta le cordinate XY
    ''' </summary>
    Public Sub [Set](c As ILocated) Implements IMovable.Set
        'imposta la cordinata
        Me.X = c.GetX
        Me.Y = c.GetY
    End Sub
    ''' <summary>
    ''' Imposta le cordinate XY
    ''' </summary>
    Public Sub [Set](x As Integer, y As Integer) Implements IMovable.Set
        'imposta le cordinate
        Me.X = x
        Me.Y = y
    End Sub
    ''' <summary>
    ''' Imposta la cordinata X
    ''' </summary>
    ''' <param name="value">Valore da impostare</param>
    Public Sub SetX(value As Integer) Implements IMovable.SetX
        'imposta la cordinata
        Me.X = value
    End Sub
    ''' <summary>
    ''' Imposta la cordinata Y
    ''' </summary>
    ''' <param name="value">Valore da impostare</param>
    Public Sub SetY(value As Integer) Implements IMovable.SetY
        'imposta la cordinata
        Me.Y = value
    End Sub
End Class
