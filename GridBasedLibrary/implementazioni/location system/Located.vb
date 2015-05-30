''' <summary>
''' Rappresenta un oggetto localizzato
''' </summary>
Public MustInherit Class Located
    Implements ILocated

    ''' <summary>
    ''' Cordinata X
    ''' </summary>
    Protected X As Integer
    ''' <summary>
    ''' Cordinata Y
    ''' </summary>
    Protected Y As Integer

    ''' <summary>
    ''' Ottiene la cordinata X
    ''' </summary>
    ''' <returns>Cordinata X</returns>
    Function GetX() As Integer Implements ILocated.GetX
        'restituisce la cordinata X
        Return X
    End Function
    ''' <summary>
    ''' Ottiene la cordinata Y
    ''' </summary>
    ''' <returns>Cordinata Y</returns>
    Function GetY() As Integer Implements ILocated.GetY
        'restituisce la cordinata Y
        Return Y
    End Function
    ''' <summary>
    ''' Ottiene la locazione in coord
    ''' </summary>
    ''' <returns>La locazione</returns>
    Function GetLocation() As Coord Implements ILocated.GetLocation
        'restituisce la locazione espresso in coord
        Return New Coord(X, Y)
    End Function
    ''' <summary>
    ''' Ottiene il valore di localizzazione
    ''' </summary>
    ''' <returns>Valore espresso in |--32bit--X--|--32bit--Y--|</returns>
    ''' <remarks>E' utile solo nelle operazioni di serializzazione/deserializzazione</remarks>
    Function GetLocationValue() As ULong Implements ILocated.GetLocationValue
        'restituisce il valore formattandolo in modo |--32bit--X--|--32bit--Y--|
        Return X << 32 Or Y
        'SPIEGAZIONE FORMULA
        '<< sposta di 32 bit X 'Esempio in 8bit totali e quindi 4bit di spostamento
        '0000XXXX << 4 --> XXXX0000
        'vengono sovrapposti Y(sovrascrive gli 0
        'XXXX0000 or 0000YYYY --> XXXXYYYY
    End Function

    ''' <summary>
    ''' Ottiene la cordinata in alto
    ''' </summary>
    ''' <returns>Cordinata (x,y-1)</returns>
    Function GetUp() As Coord Implements ILocated.GetUp
        'Restituisce la Cordinata (x,y-1)
        Return New Coord(X, Y - 1)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in alto a destra
    ''' </summary>
    ''' <returns>Cordinata (x+1,y-1)</returns>
    Function GetRightUp() As Coord Implements ILocated.GetRightUp
        'Restituisce la Cordinata (x+1,y-1)
        Return New Coord(X + 1, Y - 1)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata a destra
    ''' </summary>
    ''' <returns>Cordinata (x+1,y)</returns>
    Function GetRight() As Coord Implements ILocated.GetRight
        'Restituisce la Cordinata (x+1,y)
        Return New Coord(X + 1, Y)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in basso a destra
    ''' </summary>
    ''' <returns>Cordinata (x+1,y+1)</returns>
    Function GetRightDown() As Coord Implements ILocated.GetRightDown
        'Restituisce la Cordinata (x+1,y+1)
        Return New Coord(X + 1, Y + 1)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in basso
    ''' </summary>
    ''' <returns>Cordinata (x,y+1)</returns>
    Function GetDown() As Coord Implements ILocated.GetDown
        'Restituisce la Cordinata (x,y+1)
        Return New Coord(X, Y + 1)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in basso a sinistra
    ''' </summary>
    ''' <returns>Cordinata (x-1,y+1)</returns>
    Function GetLeftDown() As Coord Implements ILocated.GetLeftDown
        'Restituisce la Cordinata (x-1,y+1)
        Return New Coord(X - 1, Y + 1)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata a sinistra
    ''' </summary>
    ''' <returns>Cordinata (x-1,y)</returns>
    Function GetLeft() As Coord Implements ILocated.GetLeft
        'Restituisce la Cordinata (x-1,y)
        Return New Coord(X - 1, Y)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in alto a sinistra
    ''' </summary>
    ''' <returns>Cordinata (x-1,y-1)</returns>
    Function GetLeftUp() As Coord Implements ILocated.GetLeftUp
        'Restituisce la Cordinata (x-1,y-1)
        Return New Coord(X - 1, Y - 1)
    End Function

    ''' <summary>
    ''' Ottiene la cordinata in alto
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x,y-o)</returns>
    Function GetUp(offset As Integer) As Coord Implements ILocated.GetUp
        'Restituisce la Cordinata (x,y-o)
        Return New Coord(X, Y - offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in alto a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x+o,y-o)</returns>
    Function GetRightUp(offset As Integer) As Coord Implements ILocated.GetRightUp
        'Restituisce la Cordinata (x+o,y-o)
        Return New Coord(X + offset, Y - offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x+o,y)</returns>
    Function GetRight(offset As Integer) As Coord Implements ILocated.GetRight
        'Restituisce la Cordinata (x+o,y)
        Return New Coord(X + offset, Y)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in basso a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x+o,y+o)</returns>
    Function GetRightDown(offset As Integer) As Coord Implements ILocated.GetRightDown
        'Restituisce la Cordinata (x+o,y+o)
        Return New Coord(X + offset, Y + offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in basso
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x,y+o)</returns>
    Function GetDown(offset As Integer) As Coord Implements ILocated.GetDown
        'Restituisce la Cordinata (x,y+o)
        Return New Coord(X, Y + offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in basso a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x-o,y+o)</returns>
    Function GetLeftDown(offset As Integer) As Coord Implements ILocated.GetLeftDown
        'Restituisce la Cordinata (x-o,y+o)
        Return New Coord(X - offset, Y + offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x-o,y)</returns>
    Function GetLeft(offset As Integer) As Coord Implements ILocated.GetLeft
        'Restituisce la Cordinata (x-o,y)
        Return New Coord(X - offset, Y)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in alto a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x-o,y-o)</returns>
    Function GetLeftUp(offset As Integer) As Coord Implements ILocated.GetLeftUp
        'Restituisce la Cordinata (x-o,y-o)
        Return New Coord(X - offset, Y - offset)
    End Function

    ''' <summary>
    ''' Ottiene la cordinata in base alla <paramref name="direction">direzione</paramref>
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    ''' <returns>(x+CoeDirX, y+CoeDirY)</returns>
    Function GetCoordByDirection(ByVal direction As Direction) As Coord Implements ILocated.GetCoordByDirection
        'restituisce la cordinata (x+k.x, y+k.y)
        Return New Coord(X + direction.GetCoefficientX, Y + direction.GetCoefficientY)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in base alla <paramref name="direction">direzione</paramref>
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    ''' <param name="offset">Offset</param>
    ''' <returns>(x+CoeDirX*offset, y+CoeDirY*offset)</returns>
    Function GetCoordByDirection(ByVal direction As Direction, offset As Integer) As Coord Implements ILocated.GetCoordByDirection
        'restituisce la cordinata (x+k.xo, y+k.yo)
        Return New Coord(X + direction.GetCoefficientX * offset, Y + direction.GetCoefficientY * offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in base all' offset
    ''' </summary>
    ''' <param name="offx">Offset X</param>
    ''' <param name="offy">Offset Y</param>
    ''' <returns>Cordinata</returns>
    Function GetCoordByOffset(ByVal offx As Integer, offy As Integer) As Coord Implements ILocated.GetCoordByOffset
        'restituisce la cordinata offsettandolo
        Return New Coord(X + offx, Y + offy)
    End Function

End Class
