''' <summary>
''' Rappresenta un attore
''' </summary>
''' <remarks>Utilizza un algoritmo basato sulla velocità</remarks>
Public Class HSActor
    Inherits Actor

    ''' <summary>
    ''' Ottiene o imposta il nome dell' attore
    ''' </summary>
    Protected name As String

    ''' <summary>
    ''' Sposta l'attore di offset
    ''' </summary>
    ''' <param name="offx">Offset X</param>
    ''' <param name="offy">Offset Y</param>
    Public Overrides Sub MoveByOffset(offx As Integer, offy As Integer)
        'crea le variabili che contiene src e dest
        Dim src As IMapTile = GetMap().GetMapTile(Me)
        Dim dest As IMapTile = GetMap().GetMapTile(Me.GetX + offx, Me.GetY + offy)
        'prova a verificare se è possibile in destinazione
        If Not dest.CanActorEnter(Me) Then Return
        'prova a verificare se è consentito dai eventi
        If Not src.GetTile().OnActorLeaving(Me, src, dest) Then Return
        If Not dest.GetTile().OnActorEntering(Me, src, dest) Then Return
        'esegue lo spostamento
        MyBase.MoveByOffset(offx, offy)
        src.SetActor(Nothing)
        dest.SetActor(Me)
        'esegue gli eventi post-movimento
        src.GetTile.OnActorLeaved(Me, src, dest)
        dest.GetTile.OnActorEntered(Me, src, dest)
        'notifica gli eventi alla mappa
        GetMap().NotifyChange(Me, src, dest)
    End Sub

    ''' <summary>
    ''' Restituisce il nome dell' attore
    ''' </summary>
    ''' <returns>Il nome dell' attore</returns>
    Public Overridable Function GetName() As String
        'restituisce il nome
        Return name
    End Function

    ''' <summary>
    ''' Crea l'attore di nome name alla locazione loc della mappa map
    ''' </summary>
    ''' <param name="name">Nome dell'attore</param>
    ''' <param name="loc">Locazione dell'attore</param>
    ''' <param name="map">Mappa dell' attore</param>
    Protected Sub New(name As String, loc As ILocated, map As IMap)
        'imposta il nome, la locazione e la mappa
        Me.Set(loc)
        Me.name = name
        Me.MapRef = map
    End Sub
    ''' <summary>
    ''' Crea l'attore di nome name alla locazione loc della mappa map
    ''' </summary>
    ''' <param name="name">Nome dell'attore</param>
    ''' <param name="locX">Locazione X</param>
    ''' <param name="locY">Locazione Y</param>
    ''' <param name="map">Mappa dell' attore</param>
    Protected Sub New(name As String, locX As Integer, locY As Integer, map As IMap)
        'imposta il nome, la locazione e la mappa
        Me.Set(locX, locY)
        Me.name = name
        Me.MapRef = map
    End Sub

    ''' <summary>
    ''' Crea un attore alle cordinate specificate
    ''' </summary>
    ''' <param name="name">Nome dell'attore</param>
    ''' <param name="loc">Locazione dell'attore</param>
    ''' <param name="map">Mappa dell' attore</param>
    ''' <returns>L'attore che è stato creato</returns>
    ''' <remarks>Se la funzione è fallita, viene restituito nothing</remarks>
    Public Shared Function Spawn(ByVal name As String, loc As ILocated, map As IMap) As HSActor
        'crea le informazioni dell' attore
        Dim act As New HSActor(name, loc, map)
        Dim dest As IMapTile = map.GetMapTile(loc)
        'verifica se può spawnarsi
        If Not dest.CanActorEnter(act) Then Return Nothing
        If Not dest.GetTile.OnActorEntering(act, Nothing, dest) Then Return Nothing
        'lo aggiunge alla mappa
        dest.SetActor(act)
        map.SetActor(act)
        'notifica il cambiamento
        map.NotifyChange(act, Nothing, dest)
        'restituisce l'attore
        Return act
    End Function
    ''' <summary>
    ''' Crea un attore alle cordinate specificate
    ''' </summary>
    ''' <param name="name">Nome dell'attore</param>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <param name="map">Mappa dell' attore</param>
    ''' <returns>L'attore che è stato creato</returns>
    ''' <remarks>Se la funzione è fallita, viene restituito nothing</remarks>
    Public Shared Function Spawn(ByVal name As String, x As Integer, y As Integer, map As IMap) As HSActor
        'crea le informazioni dell' attore
        Dim act As New HSActor(name, x, y, map)
        Dim dest As IMapTile = map.GetMapTile(x, y)
        'verifica se può spawnarsi
        If Not dest.CanActorEnter(act) Then Return Nothing
        If Not dest.GetTile.OnActorEntering(act, Nothing, dest) Then Return Nothing
        'lo aggiunge alla mappa
        dest.SetActor(act)
        map.SetActor(act)
        'notifica il cambiamento
        map.NotifyChange(act, Nothing, dest)
        'restituisce l'attore
        Return act
    End Function
End Class
