''' <summary>
''' Rappresenta un nodo usato nel pathFinding
''' </summary>
Public Structure PathFinderNode
    ''' <summary>
    ''' Ottiene o imposta il punteggio G valutato
    ''' </summary>
    ''' <remarks>Contiene la distanza ottimale tra il punto iniziale e finale</remarks>
    Private scoreG As Single
    ''' <summary>
    ''' Ottiene o imposta il punteggio F valutato
    ''' </summary>
    ''' <remarks>Distanza Heuristica valutata</remarks>
    Private scoreH As Single
    ''' <summary>
    ''' Ottien o imposta il punto di provenienza
    ''' </summary>
    Private cameFrom As Coord

    ''' <summary>
    ''' Imposta il punteggio G associato
    ''' </summary>
    ''' <param name="val">Valore da impostare</param>
    Public Sub SetScoreG(val As Single)
        'imposta il punteggio
        scoreG = val
    End Sub
    ''' <summary>
    ''' Imposta il punteggio G associato
    ''' </summary>
    ''' <param name="val">Valore da impostare</param>
    Public Sub SetScoreH(val As Single)
        'imposta il punteggio
        scoreH = val
    End Sub
    ''' <summary>
    ''' Imposta il punto di provenienza
    ''' </summary>
    ''' <param name="c">Punto di provenienza</param>
    Public Sub SetCameFrom(ByVal c As ILocated)
        'imposta il punto di provenienza
        cameFrom = c
    End Sub
    ''' <summary>
    ''' Imposta il punto di provenienza
    ''' </summary>
    ''' <param name="x">Cordinata X del punto di provenienza</param>
    ''' <param name="y">Cordinata Y del punto di provenienza</param>
    Public Sub SetCameFrom(ByVal x As Integer, y As Integer)
        'imposta il punto di provenienza
        cameFrom = New Coord(x, y)
    End Sub

    ''' <summary>
    ''' Restituisce il punteggio G
    ''' </summary>
    ''' <returns>Punteggio G</returns>
    Public Function GetScoreG() As Single
        'restituisce il punteggio
        Return scoreG
    End Function
    ''' <summary>
    ''' Restituisce il punteggio H
    ''' </summary>
    ''' <returns>Punteggio H</returns>
    Public Function GetScoreH() As Single
        'restituisce il punteggio
        Return scoreH
    End Function
    ''' <summary>
    ''' Restituisce il punteggio F
    ''' </summary>
    ''' <returns>Punteggio F</returns>
    Public Function GetScoreF() As Single
        'restituisce il punteggio
        Return scoreG + scoreH
    End Function
    ''' <summary>
    ''' Restituisce il punto di provenienza
    ''' </summary>
    ''' <returns>Cordinata di provenienza</returns>
    Public Function GetCameFrom() As Coord
        'restituisce la cordinata di provenienza
        Return cameFrom
    End Function

End Structure
