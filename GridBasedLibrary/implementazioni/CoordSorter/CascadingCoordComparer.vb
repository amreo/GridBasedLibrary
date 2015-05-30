''' <summary>
''' Rappresenta un comparatore a cascata che utilizza più comparatori
''' </summary>
Public NotInheritable Class CascadingCoordComparer
    Implements IComparer(Of ILocated)

    ''' <summary>
    ''' Ottiene o imposta l'array di comparatori
    ''' </summary>
    Protected comparators() As IComparer(Of ILocated)

    ''' <summary>
    ''' Crea una nuova istanza di CascadingCoordComparer
    ''' </summary>
    Public Sub New(ParamArray comparators() As IComparer(Of ILocated))
        'imposta il parametro
        Me.comparators = comparators
    End Sub

    ''' <summary>
    ''' Restituisce i comparatori
    ''' </summary>
    ''' <returns>I comparatori</returns>
    Public Function GetComparators() As IComparer(Of ILocated)()
        'restituisce i comparatori
        Return comparators
    End Function

    ''' <summary>
    ''' Compara 2 cordinate 
    ''' </summary>
    ''' <param name="c1">Cordinata X</param>
    ''' <param name="c2">Cordinata Y</param>
    ''' <returns>Maggiore di 1 se x viene prima di y, 0 se sono allo stesso livello, altrimenti minore di 1 se y viene prima di x</returns>
    Public Function Compare(c1 As ILocated, c2 As ILocated) As Integer Implements System.Collections.Generic.IComparer(Of ILocated).Compare
        'verifica se il numero n(=0) è uguale al numero di comparatori e restituisce il risultato
        If comparators.Count = 0 Then Return 0
        'calcola il valore restituito del primo comparatore
        Compare = comparators(0).Compare(c1, c2)
        'se è 0 chiama il comparatore successivo
        If Compare = 0 Then Return Compare(c1, c2, 1)
    End Function

    ''' <summary>
    ''' Compara 2 cordinate 
    ''' </summary>
    ''' <param name="c1">Cordinata X</param>
    ''' <param name="c2">Cordinata Y</param>
    ''' <param name="id">Id del comparatore da usare</param>
    ''' <returns>Maggiore di 1 se c1 viene prima di c2, 0 se sono allo stesso livello, altrimenti minore di 1 se c1 viene prima di c2</returns>
    Protected Function Compare(c1 As Coord, c2 As Coord, id As Integer) As Integer
        'verifica se il numero n(=0) è uguale al numero di comparatori e restituisce il risultato
        If comparators.Count = id Then Return 0
        'calcola il valore restituito del primo comparatore
        Compare = comparators(id).Compare(c1, c2)
        'se è 0 chiama il comparatore successivo
        If Compare = 0 Then Return Compare(c1, c2, id + 1)
    End Function
    ''' <summary>
    ''' Compara 2 cordinate 
    ''' </summary>
    ''' <param name="c1">Cordinata X</param>
    ''' <param name="c2">Cordinata Y</param>
    ''' <param name="id">Id del comparatore da usare</param>
    ''' <returns>Maggiore di 1 se x viene prima di y, 0 se sono allo stesso livello, altrimenti minore di 1 se y viene prima di x</returns>
    Protected Function Compare(c1 As ILocated, c2 As ILocated, id As Integer) As Integer
        'verifica se il numero n(=0) è uguale al numero di comparatori e restituisce il risultato
        If comparators.Count = id Then Return 0
        'calcola il valore restituito del primo comparatore
        Compare = comparators(id).Compare(c1, c2)
        'se è 0 chiama il comparatore successivo
        If Compare = 0 Then Return Compare(c1, c2, id + 1)
    End Function
End Class
