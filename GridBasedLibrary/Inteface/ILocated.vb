''' <summary>
''' Interfaccia che rappresenta la locazione di un oggetto
''' </summary>
Public Interface ILocated

    ''' <summary>
    ''' Ottiene la cordinata X
    ''' </summary>
    ''' <returns>Cordinata X</returns>
    Function GetX() As Integer
    ''' <summary>
    ''' Ottiene la cordinata Y
    ''' </summary>
    ''' <returns>Cordinata Y</returns>
    Function GetY() As Integer
    ''' <summary>
    ''' Ottiene la locazione in coord
    ''' </summary>
    ''' <returns>La locazione</returns>
    Function GetLocation() As Coord
    ''' <summary>
    ''' Ottiene il valore di localizzazione
    ''' </summary>
    ''' <returns>Valore espresso in |--32bit--X--|--32bit--Y--|</returns>
    ''' <remarks>E' utile solo nelle operazioni di serializzazione/deserializzazione</remarks>
    Function GetLocationValue() As ULong

    ''' <summary>
    ''' Ottiene la cordinata in alto
    ''' </summary>
    ''' <returns>Cordinata (x,y-1)</returns>
    Function GetUp() As Coord
    ''' <summary>
    ''' Ottiene la cordinata in alto a destra
    ''' </summary>
    ''' <returns>Cordinata (x+1,y-1)</returns>
    Function GetRightUp() As Coord
    ''' <summary>
    ''' Ottiene la cordinata a destra
    ''' </summary>
    ''' <returns>Cordinata (x+1,y)</returns>
    Function GetRight() As Coord
    ''' <summary>
    ''' Ottiene la cordinata in basso a destra
    ''' </summary>
    ''' <returns>Cordinata (x+1,y+1)</returns>
    Function GetRightDown() As Coord
    ''' <summary>
    ''' Ottiene la cordinata in basso
    ''' </summary>
    ''' <returns>Cordinata (x,y+1)</returns>
    Function GetDown() As Coord
    ''' <summary>
    ''' Ottiene la cordinata in basso a sinistra
    ''' </summary>
    ''' <returns>Cordinata (x-1,y+1)</returns>
    Function GetLeftDown() As Coord
    ''' <summary>
    ''' Ottiene la cordinata a sinistra
    ''' </summary>
    ''' <returns>Cordinata (x-1,y)</returns>
    Function GetLeft() As Coord
    ''' <summary>
    ''' Ottiene la cordinata in alto a sinistra
    ''' </summary>
    ''' <returns>Cordinata (x-1,y-1)</returns>
    Function GetLeftUp() As Coord

    ''' <summary>
    ''' Ottiene la cordinata in alto
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x,y-o)</returns>
    Function GetUp(offset As Integer) As Coord
    ''' <summary>
    ''' Ottiene la cordinata in alto a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x+o,y-o)</returns>
    Function GetRightUp(offset As Integer) As Coord
    ''' <summary>
    ''' Ottiene la cordinata a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x+o,y)</returns>
    Function GetRight(offset As Integer) As Coord
    ''' <summary>
    ''' Ottiene la cordinata in basso a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x+o,y+o)</returns>
    Function GetRightDown(offset As Integer) As Coord
    ''' <summary>
    ''' Ottiene la cordinata in basso
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x,y+o)</returns>
    Function GetDown(offset As Integer) As Coord
    ''' <summary>
    ''' Ottiene la cordinata in basso a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x-o,y+o)</returns>
    Function GetLeftDown(offset As Integer) As Coord
    ''' <summary>
    ''' Ottiene la cordinata a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x-o,y)</returns>
    Function GetLeft(offset As Integer) As Coord
    ''' <summary>
    ''' Ottiene la cordinata in alto a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x-o,y-o)</returns>
    Function GetLeftUp(offset As Integer) As Coord

    ''' <summary>
    ''' Ottiene la cordinata in base alla <paramref name="direction">direzione</paramref>
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    ''' <returns>(x+CoeDirX, y+CoeDirY)</returns>
    Function GetCoordByDirection(ByVal direction As Direction) As Coord
    ''' <summary>
    ''' Ottiene la cordinata in base alla <paramref name="direction">direzione</paramref>
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    ''' <param name="offset">Offset</param>
    ''' <returns>(x+CoeDirX*offset, y+CoeDirY*offset)</returns>
    Function GetCoordByDirection(ByVal direction As Direction, offset As Integer) As Coord
    ''' <summary>
    ''' Ottiene la cordinata in base all' offset
    ''' </summary>
    ''' <param name="offx">Offset X</param>
    ''' <param name="offy">Offset Y</param>
    ''' <returns>Cordinata</returns>
    Function GetCoordByOffset(ByVal offx As Integer, offy As Integer) As Coord

End Interface
