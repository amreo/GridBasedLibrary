''' <summary>
''' Rappresenta una cordinata
''' </summary>
Public Structure Coord
    Implements IMovable

    ''' <summary>
    ''' Cordinata X
    ''' </summary>
    Private X As Integer
    ''' <summary>
    ''' Cordinata Y
    ''' </summary>
    Private Y As Integer

    ''' <summary>
    ''' Crea una nuova struttura Coord
    ''' </summary>
    ''' <param name="X">Cordinata X</param>
    ''' <param name="Y">Cordinata Y</param>
    Public Sub New(X As Integer, Y As Integer)
        'imposta le coordinate
        Me.X = X
        Me.Y = Y
    End Sub
    ''' <summary>
    ''' Crea una nuova struttura Coord
    ''' </summary>
    ''' <param name="source">Cordinata originale</param>
    ''' <remarks>Viene copiato solo il valore</remarks>
    Public Sub New(source As Coord)
        'imposta le coordinate
        Me.X = source.X
        Me.Y = source.Y
    End Sub
    ''' <summary>
    ''' Crea una nuova struttura Coord
    ''' </summary>
    ''' <param name="source">Oggetto localizzato originale originale</param>
    ''' <remarks>Viene copiato solo il valore</remarks>
    Public Sub New(source As ILocated)
        'imposta le coordinate
        Me.X = source.GetX
        Me.Y = source.GetY
    End Sub
    ''' <summary>
    ''' Crea una nuova struttura Coord
    ''' </summary>
    ''' <param name="source">Cordinata originale. Espressa in |--32bit--X--|--32bit--Y--|</param>
    ''' <remarks>Utile nelle serializzazioni</remarks>
    Public Sub New(source As Long)
        'imposta le coordinate
        Me.X = source And &HFFFFFFFF00000000
        Me.Y = source And &HFFFFFFFF
    End Sub
    ''' <summary>
    ''' Crea una nuova struttura Coord
    ''' </summary>
    ''' <param name="source">Cordinata originale. Espressa in |--32bit--X--|--32bit--Y--|</param>
    ''' <remarks>Utile nelle serializzazioni</remarks>
    Public Sub New(source As ULong)
        'imposta le coordinate
        Me.X = source And &HFFFFFFFF00000000
        Me.Y = source And &HFFFFFFFF
    End Sub
    ''' <summary>
    ''' Crea una nuova struttura Coord
    ''' </summary>
    ''' <param name="source">Cordinata originale. Espressa in |--16bit--X--|--16bit--Y--|</param>
    ''' <remarks>Utile nelle serializzazioni</remarks>
    Public Sub New(source As Integer)
        'imposta le coordinate
        Me.X = source And &HFFFF0000
        Me.Y = source And &HFFFF
    End Sub
    ''' <summary>
    ''' Crea una nuova struttura Coord
    ''' </summary>
    ''' <param name="source">Cordinata originale. Espressa in |--16bit--X--|--16bit--Y--|</param>
    ''' <remarks>Utile nelle serializzazioni</remarks>
    Public Sub New(source As UInteger)
        'imposta le coordinate
        Me.X = source And &HFFFF0000
        Me.Y = source And &HFFFF
    End Sub
    ''' <summary>
    ''' Crea una nuova struttura Coord
    ''' </summary>
    ''' <param name="source">Cordinata originale. Espressa in |--8bit--X--|--8bit--Y--|</param>
    ''' <remarks>Utile nelle serializzazioni</remarks>
    Public Sub New(source As Short)
        'imposta le coordinate
        Me.X = source And &HFF00
        Me.Y = source And &HFF
    End Sub
    ''' <summary>
    ''' Crea una nuova struttura Coord
    ''' </summary>
    ''' <param name="source">Cordinata originale. Espressa in |--8bit--X--|--8bit--Y--|</param>
    ''' <remarks>Utile nelle serializzazioni</remarks>
    Public Sub New(source As UShort)
        'imposta le coordinate
        Me.X = source And &HFF00
        Me.Y = source And &HFF
    End Sub

    ''' <summary>
    ''' Imposta la cordinata X
    ''' </summary>
    ''' <param name="value">Valore da impostare</param>
    Public Sub SetX(value As Integer) Implements IMovable.SetX
        'imposta la cordinata x
        X = value
    End Sub
    ''' <summary>
    ''' Imposta la cordinata Y
    ''' </summary>
    ''' <param name="value">Valore da impostare</param>
    Public Sub SetY(value As Integer) Implements IMovable.SetY
        'imposta la cordinata y
        Y = value
    End Sub
    ''' <summary>
    ''' Imposta le cordinate XY
    ''' </summary>
    Public Sub [Set](x As Integer, y As Integer) Implements IMovable.Set
        'imposta le cordinate x e y
        Me.X = x
        Me.Y = y
    End Sub
    ''' <summary>
    ''' Imposta le cordinate XY
    ''' </summary>
    Public Sub [Set](c As ILocated) Implements IMovable.Set
        'imposta le cordinate
        Me.X = c.GetX
        Me.Y = c.GetY
    End Sub

    ''' <summary>
    ''' Ottiene la cordinata X
    ''' </summary>
    ''' <returns>Cordinata X</returns>
    Function GetX() As Integer Implements IMovable.GetX
        'restituisce la cordinata X
        Return X
    End Function
    ''' <summary>
    ''' Ottiene la cordinata Y
    ''' </summary>
    ''' <returns>Cordinata Y</returns>
    Function GetY() As Integer Implements IMovable.GetY
        'restituisce la cordinata Y
        Return Y
    End Function
    ''' <summary>
    ''' Ottiene la locazione in coord
    ''' </summary>
    ''' <returns>La locazione</returns>
    Function GetLocation() As Coord Implements IMovable.GetLocation
        'restituisce la locazione espresso in coord
        Return New Coord(X, Y)
    End Function
    ''' <summary>
    ''' Ottiene il valore di localizzazione
    ''' </summary>
    ''' <returns>Valore espresso in |--32bit--X--|--32bit--Y--|</returns>
    ''' <remarks>E' utile solo nelle operazioni di serializzazione/deserializzazione</remarks>
    Function GetLocationValue() As ULong Implements IMovable.GetLocationValue
        'restituisce il valore formattandolo in modo |--32bit--X--|--32bit--Y--|
        Return CLng(X) << 32 Or Y
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
    Function GetUp() As Coord Implements IMovable.GetUp
        'Restituisce la Cordinata (x,y-1)
        Return New Coord(X, Y - 1)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in alto a destra
    ''' </summary>
    ''' <returns>Cordinata (x+1,y-1)</returns>
    Function GetRightUp() As Coord Implements IMovable.GetRightUp
        'Restituisce la Cordinata (x+1,y-1)
        Return New Coord(X + 1, Y - 1)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata a destra
    ''' </summary>
    ''' <returns>Cordinata (x+1,y)</returns>
    Function GetRight() As Coord Implements IMovable.GetRight
        'Restituisce la Cordinata (x+1,y)
        Return New Coord(X + 1, Y)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in basso a destra
    ''' </summary>
    ''' <returns>Cordinata (x+1,y+1)</returns>
    Function GetRightDown() As Coord Implements IMovable.GetRightDown
        'Restituisce la Cordinata (x+1,y+1)
        Return New Coord(X + 1, Y + 1)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in basso
    ''' </summary>
    ''' <returns>Cordinata (x,y+1)</returns>
    Function GetDown() As Coord Implements IMovable.GetDown
        'Restituisce la Cordinata (x,y+1)
        Return New Coord(X, Y + 1)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in basso a sinistra
    ''' </summary>
    ''' <returns>Cordinata (x-1,y+1)</returns>
    Function GetLeftDown() As Coord Implements IMovable.GetLeftDown
        'Restituisce la Cordinata (x-1,y+1)
        Return New Coord(X - 1, Y + 1)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata a sinistra
    ''' </summary>
    ''' <returns>Cordinata (x-1,y)</returns>
    Function GetLeft() As Coord Implements IMovable.GetLeft
        'Restituisce la Cordinata (x-1,y)
        Return New Coord(X - 1, Y)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in alto a sinistra
    ''' </summary>
    ''' <returns>Cordinata (x-1,y-1)</returns>
    Function GetLeftUp() As Coord Implements IMovable.GetLeftUp
        'Restituisce la Cordinata (x-1,y-1)
        Return New Coord(X - 1, Y - 1)
    End Function

    ''' <summary>
    ''' Ottiene la cordinata in alto
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x,y-o)</returns>
    Function GetUp(offset As Integer) As Coord Implements IMovable.GetUp
        'Restituisce la Cordinata (x,y-o)
        Return New Coord(X, Y - offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in alto a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x+o,y-o)</returns>
    Function GetRightUp(offset As Integer) As Coord Implements IMovable.GetRightUp
        'Restituisce la Cordinata (x+o,y-o)
        Return New Coord(X + offset, Y - offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x+o,y)</returns>
    Function GetRight(offset As Integer) As Coord Implements IMovable.GetRight
        'Restituisce la Cordinata (x+o,y)
        Return New Coord(X + offset, Y)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in basso a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x+o,y+o)</returns>
    Function GetRightDown(offset As Integer) As Coord Implements IMovable.GetRightDown
        'Restituisce la Cordinata (x+o,y+o)
        Return New Coord(X + offset, Y + offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in basso
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x,y+o)</returns>
    Function GetDown(offset As Integer) As Coord Implements IMovable.GetDown
        'Restituisce la Cordinata (x,y+o)
        Return New Coord(X, Y + offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in basso a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x-o,y+o)</returns>
    Function GetLeftDown(offset As Integer) As Coord Implements IMovable.GetLeftDown
        'Restituisce la Cordinata (x-o,y+o)
        Return New Coord(X - offset, Y + offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x-o,y)</returns>
    Function GetLeft(offset As Integer) As Coord Implements IMovable.GetLeft
        'Restituisce la Cordinata (x-o,y)
        Return New Coord(X - offset, Y)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in alto a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata (x-o,y-o)</returns>
    Function GetLeftUp(offset As Integer) As Coord Implements IMovable.GetLeftUp
        'Restituisce la Cordinata (x-o,y-o)
        Return New Coord(X - offset, Y - offset)
    End Function

    ''' <summary>
    ''' Ottiene la cordinata in base alla <paramref name="direction">direzione</paramref>
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    ''' <returns>(x+CoeDirX, y+CoeDirY)</returns>
    Function GetCoordByDirection(ByVal direction As Direction) As Coord Implements IMovable.GetCoordByDirection
        'restituisce la cordinata (x+k.x, y+k.y)
        Return New Coord(X + direction.GetCoefficientX, Y + direction.GetCoefficientY)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in base alla <paramref name="direction">direzione</paramref>
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    ''' <param name="offset">Offset</param>
    ''' <returns>(x+CoeDirX*offset, y+CoeDirY*offset)</returns>
    Function GetCoordByDirection(ByVal direction As Direction, offset As Integer) As Coord Implements IMovable.GetCoordByDirection
        'restituisce la cordinata (x+k.xo, y+k.yo)
        Return New Coord(X + direction.GetCoefficientX * offset, Y + direction.GetCoefficientY * offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata in base all' offset
    ''' </summary>
    ''' <param name="offx">Offset X</param>
    ''' <param name="offy">Offset Y</param>
    ''' <returns>Cordinata</returns>
    Function GetCoordByOffset(ByVal offx As Integer, offy As Integer) As Coord Implements IMovable.GetCoordByOffset
        'restituisce la cordinata offsettandolo
        Return New Coord(X + offx, Y + offy)
    End Function


    ''' <summary>
    ''' Sposta la cordinata in alto
    ''' </summary>
    Sub MoveUp() Implements IMovable.MoveUp
        'lo sposta in alto di 1
        Y -= 1
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in alto a destra
    ''' </summary>
    Sub MoveRightUp() Implements IMovable.MoveRightUp
        'lo sposta in alto a dx di 1
        X += 1
        Y -= 1
    End Sub
    ''' <summary>
    ''' Sposta la cordinata a destra
    ''' </summary>
    Sub MoveRight() Implements IMovable.MoveRight
        'lo sposta a dx di 1
        X += 1
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in basso a destra
    ''' </summary>
    Sub MoveRightDown() Implements IMovable.MoveRightDown
        'lo sposta in basso a dx di 1
        X += 1
        Y += 1
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in basso
    ''' </summary>
    Sub MoveDown() Implements IMovable.MoveDown
        'lo sposta in basso di 1
        Y += 1
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in basso a sinistra
    ''' </summary>
    Sub MoveLeftDown() Implements IMovable.MoveLeftDown
        'lo sposta in basso a sx di 1
        X -= 1
        Y += 1
    End Sub
    ''' <summary>
    ''' Sposta la cordinata a sinistra
    ''' </summary>
    Sub MoveLeft() Implements IMovable.MoveLeft
        'lo sposta a sx di 1
        X -= 1
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in alto a sinistra
    ''' </summary>
    Sub MoveLeftUp() Implements IMovable.MoveLeftUp
        'lo sposta in basso a sx di 1
        X -= 1
        Y -= 1
    End Sub

    ''' <summary>
    ''' Sposta la cordinata in alto
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveUp(offset As Integer) Implements IMovable.MoveUp
        'lo sposta in alto di offset
        Y -= offset
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in alto a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveRightUp(offset As Integer) Implements IMovable.MoveRightUp
        'lo sposta in alto a dx di offset
        X += offset
        Y -= offset
    End Sub
    ''' <summary>
    ''' Sposta la cordinata a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveRight(offset As Integer) Implements IMovable.MoveRight
        'lo sposta a dx di offset
        X += offset
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in basso a destra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveRightDown(offset As Integer) Implements IMovable.MoveRightDown
        'lo sposta in basso a dx di offset
        X += offset
        Y += offset
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in basso
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveDown(offset As Integer) Implements IMovable.MoveDown
        'lo sposta in basso di offset
        Y += offset
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in basso a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveLeftDown(offset As Integer) Implements IMovable.MoveLeftDown
        'lo sposta in basso a sx di offset
        X -= offset
        Y += offset
    End Sub
    ''' <summary>
    ''' Sposta la cordinata a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveLeft(offset As Integer) Implements IMovable.MoveLeft
        'lo sposta a dx di offset
        X -= offset
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in alto a sinistra
    ''' </summary>
    ''' <param name="offset">Offset</param>
    Sub MoveLeftUp(offset As Integer) Implements IMovable.MoveLeftUp
        'lo sposta in alto a sx di offset
        X -= offset
        Y -= offset
    End Sub

    ''' <summary>
    ''' Sposta la cordinata in base alla <paramref name="direction">direzione</paramref>
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    Sub MoveByDirection(ByVal direction As Direction) Implements IMovable.MoveByDirection
        'sposta verso la direzione di 1
        X += direction.GetCoefficientX
        Y += direction.GetCoefficientY
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in base alla <paramref name="direction">direzione</paramref>
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    ''' <param name="offset">Offset</param>
    Sub MoveByDirection(ByVal direction As Direction, offset As Integer) Implements IMovable.MoveByDirection
        'sposta verso la direzione di 1
        X += direction.GetCoefficientX * offset
        Y += direction.GetCoefficientY * offset
    End Sub
    ''' <summary>
    ''' Sposta la cordinata in base all' offset
    ''' </summary>
    ''' <param name="offx">Offset X</param>
    ''' <param name="offy">Offset Y</param>
    Sub MoveByOffset(ByVal offx As Integer, offy As Integer) Implements IMovable.MoveByOffset
        'sposta la coordinata aggiungendo gli off*
        X += offx
        Y += offy
    End Sub
    ''' <summary>
    ''' Sposta la cordinata a destinazione
    ''' </summary>
    ''' <param name="destX">Destinazione X</param>
    ''' <param name="destY">Destinazione Y</param>
    Sub MoveTo(ByVal destX As Integer, destY As Integer) Implements IMovable.MoveTo
        'sposta la cordinata verso la destinazione
        X = destX
        Y = destY
    End Sub
    ''' <summary>
    ''' Sposta la cordinata a destinazione
    ''' </summary>
    ''' <param name="dest">Destinazione</param>
    Sub MoveTo(ByVal dest As ILocated) Implements IMovable.MoveTo
        'sposta la cordinata verso la destinazione
        X = dest.GetX
        Y = dest.GetY
    End Sub



    ''' <summary>
    ''' Rappresenta in formato string la cordinata
    ''' </summary>
    ''' <returns>Espressa in ($x,$y)</returns>
    Public Overrides Function ToString() As String
        'restituisce la rappresentazione in string
        Return "(" & X.ToString & "," & Y.ToString & ")"
    End Function


    Public Shared Operator <>(ByVal left As Coord, ByVal right As Coord) As Boolean
        'verifica che sono diversi sia in x che y
        Return (left.X <> right.X) Or (left.Y <> right.Y)
    End Operator
    Public Shared Operator =(ByVal left As Coord, ByVal right As Coord) As Boolean
        'verifica che sono uguali sia in x che y
        Return (left.X = right.X) And (left.Y = right.Y)
    End Operator
    Public Shared Operator <>(ByVal left As Coord, ByVal right As ILocated) As Boolean
        'verifica che sono diversi sia in x che y
        Return (left.X <> right.GetX) Or (left.Y <> right.GetY)
    End Operator
    Public Shared Operator =(ByVal left As Coord, ByVal right As ILocated) As Boolean
        'verifica che sono uguali sia in x che y
        Return (left.X = right.GetX) And (left.Y = right.GetY)
    End Operator
    Public Shared Operator <>(ByVal left As ILocated, ByVal right As Coord) As Boolean
        'verifica che sono diversi sia in x che y
        Return (left.GetX <> right.X) Or (left.GetY <> right.Y)
    End Operator
    Public Shared Operator =(ByVal left As ILocated, ByVal right As Coord) As Boolean
        'verifica che sono uguali sia in x che y
        Return (left.GetX = right.X) And (left.GetY = right.Y)
    End Operator
End Structure
