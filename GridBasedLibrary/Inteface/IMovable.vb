''' <summary>
''' Rappresenta un oggetto in grado di spostarsi
''' </summary>
Public Interface IMovable
    Inherits ILocated

    ''' <summary>
    ''' Imposta la cordinata X
    ''' </summary>
    ''' <param name="value">Valore da impostare</param>
    Sub SetX(value As Integer)
    ''' <summary>
    ''' Imposta la cordinata Y
    ''' </summary>
    ''' <param name="value">Valore da impostare</param>
    Sub SetY(value As Integer)
    ''' <summary>
    ''' Imposta le cordinate XY
    ''' </summary>
    Sub [Set](x As Integer, y As Integer)
    ''' <summary>
    ''' Imposta le cordinate XY
    ''' </summary>
    Sub [Set](c As ILocated)

    ''' <summary>
    ''' Sposta la cordinata in alto
    ''' </summary>
    Sub MoveUp()
    ''' <summary>
    ''' Sposta la cordinata in alto a destra
    ''' </summary>
    Sub MoveRightUp()
    ''' <summary>
    ''' Sposta la cordinata a destra
    ''' </summary>
    Sub MoveRight()
    ''' <summary>
    ''' Sposta la cordinata in basso a destra
    ''' </summary>
    Sub MoveRightDown()
    ''' <summary>
    ''' Sposta la cordinata in basso
    ''' </summary>
    Sub MoveDown()
    ''' <summary>
    ''' Sposta la cordinata in basso a sinistra
    ''' </summary>
    Sub MoveLeftDown()
    ''' <summary>
    ''' Sposta la cordinata a sinistra
    ''' </summary>
    Sub MoveLeft()
    ''' <summary>
    ''' Sposta la cordinata in alto a sinistra
    ''' </summary>
    Sub MoveLeftUp()

    ''' <summary>
    ''' Sposta la cordinata in alto
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveUp(offset As Integer)
    ''' <summary>
    ''' Sposta la cordinata in alto a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveRightUp(offset As Integer)
    ''' <summary>
    ''' Sposta la cordinata a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveRight(offset As Integer)
    ''' <summary>
    ''' Sposta la cordinata in basso a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveRightDown(offset As Integer)
    ''' <summary>
    ''' Sposta la cordinata in basso
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveDown(offset As Integer)
    ''' <summary>
    ''' Sposta la cordinata in basso a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveLeftDown(offset As Integer)
    ''' <summary>
    ''' Sposta la cordinata a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveLeft(offset As Integer)
    ''' <summary>
    ''' Sposta la cordinata in alto a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveLeftUp(offset As Integer)

    ''' <summary>
    ''' Sposta la cordinata in base alla <paramref name="direction">direzione</paramref>
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    Sub MoveByDirection(ByVal direction As Direction)
    ''' <summary>
    ''' Sposta la cordinata in base alla <paramref name="direction">direzione</paramref>
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    ''' <param name="offset">Offset</param>
    Sub MoveByDirection(ByVal direction As Direction, offset As Integer)
    ''' <summary>
    ''' Sposta la cordinata in base all' offset
    ''' </summary>
    ''' <param name="offx">Offset X</param>
    ''' <param name="offy">Offset Y</param>
    Sub MoveByOffset(ByVal offx As Integer, offy As Integer)
    ''' <summary>
    ''' Sposta la cordinata a destinazione
    ''' </summary>
    ''' <param name="destX">Destinazione X</param>
    ''' <param name="destY">Destinazione Y</param>
    Sub MoveTo(ByVal destX As Integer, destY As Integer)
    ''' <summary>
    ''' Sposta la cordinata a destinazione
    ''' </summary>
    ''' <param name="dest">Destinazione</param>
    Sub MoveTo(ByVal dest As ILocated)
End Interface
