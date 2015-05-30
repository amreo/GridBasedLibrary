''' <summary>
''' Rappresenta un rettangolo
''' </summary>
Public Class Rectangle
    Inherits Movable

    ''' <summary>
    ''' Elenco di costanti che identificano il modo di scegliere le cordinate(celle) del rettangolo
    ''' </summary>
    <Flags()>
    Public Enum SelectionRectangleMode
        ''' <summary>
        ''' Non seleziona nulla
        ''' </summary>
        NONE = 0
        ''' <summary>
        ''' Seleziona il perimetro del rettangolo(interno)
        ''' </summary>
        PERIMETER = 1
        ''' <summary>
        ''' Seleziona l'area interna del rettangolo
        ''' </summary>
        INTERNAL_AREA = 2
        ''' <summary>
        ''' Seleziona tutta l'area del rettangolo
        ''' </summary>
        AREA = PERIMETER Or INTERNAL_AREA
    End Enum

    ''' <summary>
    ''' Ottiene o imposta le dimensioni del rettangolo
    ''' </summary>
    Protected size As Size

    ''' <summary>
    ''' Crea una nuova istanza di rectangle
    ''' </summary>
    ''' <param name="X">Locazione X</param>
    ''' <param name="Y">Locazione Y</param>
    ''' <param name="Width">Larghezza</param>
    ''' <param name="Height">Altezza</param>
    Public Sub New(X As Integer, Y As Integer, Width As UInteger, Height As UInteger)
        'Imposta le variabili
        Me.X = X
        Me.Y = Y
        Me.size.SetWidth(Width)
        Me.size.SetHeight(Height)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di rectangle
    ''' </summary>
    ''' <param name="location">Locazione del rettangolo</param>
    ''' <param name="size">Dimensioni del rettangolo</param>
    Public Sub New(location As Coord, size As Size)
        'Imposta le variabili
        [Set](location)
        Me.size = size
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di rectangle
    ''' </summary>
    ''' <param name="location">Locazione del rettangolo</param>
    ''' <param name="size">Dimensioni del rettangolo</param>
    Public Sub New(location As ILocated, size As Size)
        'Imposta le variabili
        [Set](location)
        Me.size = size
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di rectangle
    ''' </summary>
    ''' <param name="src">Rettangolo sorgente</param>
    Public Sub New(src As Rectangle)
        'Imposta le variabili
        [Set](src.GetX, src.GetY)
        Me.size = size
    End Sub

    ''' <summary>
    ''' Ottiene la larghezza del rettangolo
    ''' </summary>
    ''' <returns>La larghezza</returns>
    Public Function GetWidth() As UInteger
        'restituisce Width
        Return size.GetWidth
    End Function
    ''' <summary>
    ''' Ottiene l'altezza del rettangolo
    ''' </summary>
    ''' <returns>L'altezza</returns>
    Public Function GetHeight() As UInteger
        'restituisce height
        Return size.GetHeight
    End Function
    ''' <summary>
    ''' Ottiene le dimensioni di default del rettangolo
    ''' </summary>
    ''' <returns>Le dimensioni</returns>
    Public Function GetSize() As Size
        'restituisce le dimensioni
        Return size
    End Function

    ''' <summary>
    ''' Imposta la larghezza del rettangolo
    ''' </summary>
    ''' <param name="value">Valore da impostare</param>
    Public Sub SetWidth(value As UInteger)
        'imposta la larghezza
        size.SetWidth(value)
    End Sub
    ''' <summary>
    ''' Imposta l'altezza del rettangolo
    ''' </summary>
    ''' <param name="value">Valore</param>
    Public Sub SetHeight(value As UInteger)
        'imposta l'altezza
        size.SetHeight(value)
    End Sub
    ''' <summary>
    ''' Imposta le dimensioni del rettangolo
    ''' </summary>
    ''' <param name="value">Nuove dimensioni</param>
    Public Sub SetSize(value As Size)
        'imposta le dimensioni
        size = value
    End Sub
    ''' <summary>
    ''' Imposta le dimensioni del rettangolo
    ''' </summary>
    ''' <param name="width">La nuova larghezza</param>
    ''' <param name="height">La nuova altezza</param>
    Public Sub SetSize(width As UInteger, height As UInteger)
        'imposta le dimensioni
        size.SetWidth(width)
        size.SetHeight(height)
    End Sub


    ''' <summary>
    ''' Seleziona determinate zone del rettangolo
    ''' </summary>
    ''' <param name="mode">Modalità di selezione</param>
    ''' <param name="selRes">Selecter da usare</param>
    ''' <param name="deSelectAll">Se deselezionare tutti i punti in selRes prima di eseguire il metodo</param>
    ''' <remarks>Il parametro mode supporta più opzioni</remarks>
    Public Sub SelectRectangleRegion(mode As SelectionRectangleMode, selRes As ICoordSelecter, deSelectAll As Boolean)
        'verifica che deSelectAll sia vero per pulire
        If deSelectAll Then selRes.DeSelectAll()
        'verifica le varie flag
        'perimetro
        If mode.HasFlag(SelectionRectangleMode.PERIMETER) Then
            'cicla il perimetro
            For _X = GetX() To GetX() + GetWidth() - 1
                'seleziona la cordinata
                selRes.Select(_X, GetY)
                selRes.Select(_X, GetY() + GetHeight() - 1)
            Next
            For _Y = GetY() + 1 To GetY() + GetHeight() - 2
                'seleziona la cordinata
                selRes.Select(GetX, _Y)
                selRes.Select(GetX() + GetWidth() - 1, _Y)
            Next
        End If
        'area interna
        If mode.HasFlag(SelectionRectangleMode.INTERNAL_AREA) Then
            'cicla x e y
            For _X = GetX() + 1 To GetX() + GetWidth() - 2
                For _Y = GetY() + 1 To GetY() + GetHeight() - 2
                    'seleziona la cordinata
                    selRes.Select(_X, _Y)
                Next
            Next
        End If
    End Sub

    ''' <summary>
    ''' Verifica se il rettangolo contiene il punto
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    ''' <returns>True se contiene il punto, altrimenti false</returns>
    Public Function Contains(x As Integer, y As Integer) As Boolean
        'verifica con le condizioni
        '  me.x<=x<me.x+getWidth()
        '  me.y<=y<me.y+getHeight()
        Return Me.X <= x And x < Me.X + GetWidth() And Me.Y <= y And y < Me.Y + GetHeight()
    End Function
    ''' <summary>
    ''' Verifica se il rettangolo contiene il punto
    ''' </summary>
    ''' <param name="c">Cordinata da verificare</param>
    ''' <returns>True se contiene il punto, altrimenti false</returns>
    Public Function Contains(c As Coord) As Boolean
        'verifica con le condizioni
        '  x<=c.x<x+getWidth()
        '  y<=c.y<y+getHeight()
        Return X <= c.GetX And c.GetX < X + GetWidth() And Y <= c.GetY And c.GetY < Y + GetHeight()
    End Function
    ''' <summary>
    ''' Verifica se il rettangolo contiene il punto
    ''' </summary>
    ''' <param name="c">Cordinata da verificare</param>
    ''' <returns>True se contiene il punto, altrimenti false</returns>
    Public Function Contains(c As ILocated) As Boolean
        'verifica con le condizioni
        '  x<=c.x<x+getWidth()
        '  y<=c.y<y+getHeight()
        Return X <= c.GetX And c.GetX < X + GetWidth() And Y <= c.GetY And c.GetY < Y + GetHeight()
    End Function
End Class