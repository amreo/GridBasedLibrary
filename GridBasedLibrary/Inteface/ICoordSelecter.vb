''' <summary>
''' Rappresenta un selettore di coordinate
''' </summary>
Public Interface ICoordSelecter
    Inherits IEnumerable(Of Coord)

    ''' <summary>
    ''' Seleziona una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Sub [Select](ByVal x As Integer, ByVal y As Integer)
    ''' <summary>
    ''' Seleziona una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da selezionare</param>
    Sub [Select](ByVal c As ILocated)
    ''' <summary>
    ''' Seleziona una cordinata
    ''' </summary>
    ''' <param name="Coords">Cordinate da selezionare</param>
    Sub [Select](ByVal ParamArray Coords As ILocated())

    ''' <summary>
    ''' Deseleziona una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Sub DeSelect(ByVal x As Integer, ByVal y As Integer)
    ''' <summary>
    ''' Deseleziona una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da deselezionare</param>
    Sub DeSelect(ByVal c As ILocated)
    ''' <summary>
    ''' Deseleziona una cordinata
    ''' </summary>
    ''' <param name="Coords">Cordinate da deselezionare</param>
    Sub DeSelect(ByVal ParamArray Coords As ILocated())
    ''' <summary>
    ''' Deseleziona tutte le cordinate
    ''' </summary>
    Sub DeSelectAll()


    ''' <summary>
    ''' Verifica se è selezionata una cordinata
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    Function IsSelected(ByVal x As Integer, ByVal y As Integer) As Boolean
    ''' <summary>
    ''' Verifica se è selezionata una cordinata
    ''' </summary>
    ''' <param name="c">Cordinata da verificare</param>
    Function IsSelected(ByVal c As ILocated) As Boolean
    ''' <summary>
    ''' Verifica se sono selezionate delle cordinate
    ''' </summary>
    ''' <param name="Coords">Cordinate da verificare</param>
    Function IsSelected(ByVal ParamArray Coords As ILocated()) As Boolean

    ''' <summary>
    ''' Ottiene le cordinate selezionate
    ''' </summary>
    ''' <returns>Cordinate selezionate</returns> 
    Function GetSelection() As Coord()

    ''' <summary>
    ''' Copia la selezione su dest
    ''' </summary>
    ''' <param name="dest">ICoordSelecter di destinazione di copia</param>
    ''' <param name="DeSelectAllDest">True se deselezionare tutte le cordinate, altrimenti false</param>
    Sub CopySelectionTo(ByVal dest As ICoordSelecter, Optional ByVal DeSelectAllDest As Boolean = False)
    ''' <summary>
    ''' Esegue l'operazione OR tra questa istanza e second e seleziona il risultato su dest
    ''' </summary>
    ''' <param name="second">Secondo ICoordSelecter</param>
    ''' <param name="dest">Selecter di destinazione(risultato)</param>
    ''' <param name="DeSelectAllDest">True se deselezionare dest</param>
    ''' <remarks>NB se (second is dest) e (DeSelectAllDest=True) dest è selezionato dai stessi punti di questa istanza</remarks>
    Sub OrSelectionTo(ByVal second As ICoordSelecter, ByVal dest As ICoordSelecter, Optional ByVal DeSelectAllDest As Boolean = False)
    ''' <summary>
    ''' Esegue l'operazione XOR tra questa istanza e second e seleziona il risultato su dest
    ''' </summary>
    ''' <param name="second">Secondo ICoordSelecter</param>
    ''' <param name="dest">Selecter di destinazione(risultato)</param>
    ''' <param name="DeSelectAllDest">True se deselezionare dest</param>
    ''' <remarks>NB se (second is dest) e (DeSelectAllDest=True) dest è selezionato dai stessi punti di questa istanza</remarks>
    Sub XorSelectionTo(ByVal second As ICoordSelecter, ByVal dest As ICoordSelecter, Optional ByVal DeSelectAllDest As Boolean = False)
    ''' <summary>
    ''' Esegue l'operazione And tra questa istanza e second e seleziona il risultato su dest
    ''' </summary>
    ''' <param name="second">Secondo ICoordSelecter</param>
    ''' <param name="dest">Selecter di destinazione(risultato)</param>
    ''' <param name="DeSelectAllDest">True se deselezionare dest</param>
    ''' <remarks>NB se (second is dest) e (DeSelectAllDest=True) dest non ha alcuna cordinata selezionata</remarks>
    Sub AndSelectionTo(ByVal second As ICoordSelecter, ByVal dest As ICoordSelecter, Optional ByVal DeSelectAllDest As Boolean = False)
    ''' <summary>
    ''' Esegue l'operazione differenza insiemistica tra questa istanza e second e seleziona il risultato su dest
    ''' </summary>
    ''' <param name="second">Secondo ICoordSelecter</param>
    ''' <param name="dest">Selecter di destinazione(risultato)</param>
    ''' <param name="DeSelectAllDest">True se deselezionare dest</param>
    ''' <remarks>NB se (second is dest) e (DeSelectAllDest=True) dest ha gli stesse cordinate selezionate di questa istanza</remarks>
    Sub SubSelectionTo(ByVal second As ICoordSelecter, ByVal dest As ICoordSelecter, Optional ByVal DeSelectAllDest As Boolean = False)


End Interface
