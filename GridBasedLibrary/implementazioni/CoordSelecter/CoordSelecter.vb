''' <summary>
''' Classe base per il selecter di cordinate
''' </summary>
Public MustInherit Class CoordSelecter
    Implements ICoordSelecter

    ''' <summary>
    ''' Seleziona una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Public MustOverride Sub [Select](ByVal x As Integer, ByVal y As Integer) Implements ICoordSelecter.Select

    ''' <summary>
    ''' Seleziona una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da selezionare</param>
    Public MustOverride Sub [Select](ByVal c As ILocated) Implements ICoordSelecter.Select
    ''' <summary>
    ''' Seleziona una cordinata
    ''' </summary>
    ''' <param name="Coords">Cordinate da selezionare</param>
    Public Overridable Sub [Select](ByVal ParamArray Coords As ILocated()) Implements ICoordSelecter.Select
        'cicla ogni elemento e lo seleziona
        For Each c As ILocated In Coords
            [Select](c)
        Next
    End Sub



    ''' <summary>
    ''' Deseleziona una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Public MustOverride Sub DeSelect(ByVal x As Integer, ByVal y As Integer) Implements ICoordSelecter.DeSelect
    ''' <summary>
    ''' Deseleziona una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da deselezionare</param>
    Public MustOverride Sub DeSelect(ByVal c As ILocated) Implements ICoordSelecter.DeSelect
    ''' <summary>
    ''' Deseleziona una cordinata
    ''' </summary>
    ''' <param name="Coords">Cordinate da deselezionare</param>
    Public Overridable Sub DeSelect(ByVal ParamArray Coords As ILocated()) Implements ICoordSelecter.DeSelect
        'cicla ogni elemento e lo deseleziona
        For Each c As Coord In Coords
            DeSelect(c)
        Next
    End Sub
    ''' <summary>
    ''' Deseleziona tutte le cordinate
    ''' </summary>
    Public MustOverride Sub DeSelectAll() Implements ICoordSelecter.DeSelectAll


    ''' <summary>
    ''' Verifica se è selezionata una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Public MustOverride Function IsSelected(ByVal x As Integer, ByVal y As Integer) As Boolean Implements ICoordSelecter.IsSelected
    ''' <summary>
    ''' Verifica se è selezionata una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da verificare</param>
    Public MustOverride Function IsSelected(ByVal c As ILocated) As Boolean Implements ICoordSelecter.IsSelected
    ''' <summary>
    ''' Verifica se sono selezionate delle cordinate
    ''' </summary>
    ''' <param name="Coords">Cordinate da verificare</param>
    Public Overridable Function IsSelected(ByVal ParamArray Coords As ILocated()) As Boolean Implements ICoordSelecter.IsSelected
        'cicla ogni elemento per verifica
        For Each c As ILocated In Coords
            'verifica che non è selezionato per restituire false
            If Not IsSelected(c) Then Return False
        Next
        'restituisce true
        Return True
    End Function

    ''' <summary>
    ''' Ottiene le cordinate selezionate
    ''' </summary>
    ''' <returns>Cordinate selezionate</returns> 
    Public MustOverride Function GetSelection() As Coord() Implements ICoordSelecter.GetSelection

    ''' <summary>
    ''' Copia la selezione su dest
    ''' </summary>
    ''' <param name="dest">ICoordSelecter di destinazione di copia</param>
    ''' <param name="DeSelectAllDest">True se deselezionare tutte le cordinate, altrimenti false</param>
    Public Overridable Sub CopySelectionTo(ByVal dest As ICoordSelecter, Optional ByVal DeSelectAllDest As Boolean = False) Implements ICoordSelecter.CopySelectionTo
        'verifica se è da deselezionare
        If DeSelectAllDest Then dest.DeSelectAll()
        'cicla ogni cordinata e la seleziona in dest
        For Each c As Coord In Me
            'seleziona c in dest
            dest.Select(c)
        Next
    End Sub
    ''' <summary>
    ''' Esegue l'operazione OR tra questa istanza e second e seleziona il risultato su dest
    ''' </summary>
    ''' <param name="second">Secondo ICoordSelecter</param>
    ''' <param name="dest">Selecter di destinazione(risultato)</param>
    ''' <param name="DeSelectAllDest">True se deselezionare dest</param>
    ''' <remarks>NB se (second is dest) e (DeSelectAllDest=True) dest è selezionato dai stessi punti di questa istanza</remarks>
    Public Overridable Sub OrSelectionTo(ByVal second As ICoordSelecter, ByVal dest As ICoordSelecter, Optional ByVal DeSelectAllDest As Boolean = False) Implements ICoordSelecter.OrSelectionTo
        'verifica se è da deselezionare
        If DeSelectAllDest Then dest.DeSelectAll()
        'cicla ogni cordinata e la seleziona in dest
        For Each c As Coord In Me.Union(second)
            'seleziona c in dest
            dest.Select(c)
        Next
    End Sub
    ''' <summary>
    ''' Esegue l'operazione XOR tra questa istanza e second e seleziona il risultato su dest
    ''' </summary>
    ''' <param name="second">Secondo ICoordSelecter</param>
    ''' <param name="dest">Selecter di destinazione(risultato)</param>
    ''' <param name="DeSelectAllDest">True se deselezionare dest</param>
    ''' <remarks>NB se (second is dest) e (DeSelectAllDest=True) dest è selezionato dai stessi punti di questa istanza</remarks>
    Public Overridable Sub XorSelectionTo(ByVal second As ICoordSelecter, ByVal dest As ICoordSelecter, Optional ByVal DeSelectAllDest As Boolean = False) Implements ICoordSelecter.XorSelectionTo
        'verifica se è da deselezionare
        If DeSelectAllDest Then dest.DeSelectAll()
        'cicla ogni cordinata e la seleziona in dest
        For Each c As Coord In Me.Union(second).Except(Me.Intersect(second))
            'seleziona c in dest
            dest.Select(c)
        Next
    End Sub
    ''' <summary>
    ''' Esegue l'operazione And tra questa istanza e second e seleziona il risultato su dest
    ''' </summary>
    ''' <param name="second">Secondo ICoordSelecter</param>
    ''' <param name="dest">Selecter di destinazione(risultato)</param>
    ''' <param name="DeSelectAllDest">True se deselezionare dest</param>
    ''' <remarks>NB se (second is dest) e (DeSelectAllDest=True) dest non ha alcuna cordinata selezionata</remarks>
    Public Overridable Sub AndSelectionTo(ByVal second As ICoordSelecter, ByVal dest As ICoordSelecter, Optional ByVal DeSelectAllDest As Boolean = False) Implements ICoordSelecter.AndSelectionTo
        'verifica se è da deselezionare
        If DeSelectAllDest Then dest.DeSelectAll()
        'cicla ogni cordinata e la seleziona in dest
        For Each c As Coord In Me
            'seleziona c in dest solo se è selezionato in second
            If second.IsSelected(c) Then dest.Select(c)
        Next
    End Sub
    ''' <summary>
    ''' Esegue l'operazione differenza insiemistica tra questa istanza e second e seleziona il risultato su dest
    ''' </summary>
    ''' <param name="second">Secondo ICoordSelecter</param>
    ''' <param name="dest">Selecter di destinazione(risultato)</param>
    ''' <param name="DeSelectAllDest">True se deselezionare dest</param>
    ''' <remarks>NB se (second is dest) e (DeSelectAllDest=True) dest ha gli stesse cordinate selezionate di questa istanza</remarks>
    Public Overridable Sub SubSelectionTo(ByVal second As ICoordSelecter, ByVal dest As ICoordSelecter, Optional ByVal DeSelectAllDest As Boolean = False) Implements ICoordSelecter.SubSelectionTo
        'verifica se è da deselezionare
        If DeSelectAllDest Then dest.DeSelectAll()
        'cicla ogni cordinata e la seleziona in dest
        For Each c As Coord In Me
            'seleziona c in dest solo se non è selezionato in second
            If Not second.IsSelected(c) Then dest.Select(c)
        Next
    End Sub

    ''' <summary>
    ''' Restituisce l'enumeratore usato da questa classe
    ''' </summary>
    ''' <returns>Enumeratore usato</returns>
    Public MustOverride Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of Coord) Implements System.Collections.Generic.IEnumerable(Of Coord).GetEnumerator
    ''' <summary>
    ''' Restituisce l'enumeratore usato da questa classe
    ''' </summary>
    ''' <returns>Enumeratore usato</returns>
    Public MustOverride Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator

End Class
