''' <summary>
''' Rappresenta un MapTile
''' </summary>
''' <remarks>Utilizza dei algoritmi basati sulla velocità</remarks>
Public Class HSMapTile
    Inherits Located
    Implements IMapTile

    ''' <summary>
    ''' Ottiene o imposta la mappa
    ''' </summary>
    Protected map As IMap
    ''' <summary>
    ''' Ottiene o imposta il tile
    ''' </summary>
    Protected tile As ITile
    ''' <summary>
    ''' Ottiene o imposta l'attore
    ''' </summary>
    Protected act As IActor

    ''' <summary>
    ''' Crea una nuova istanza di MapTile
    ''' </summary>
    ''' <param name="map">Mappa da usare</param>
    ''' <param name="loc">Locazione del MapTilr</param>
    Public Sub New(map As IMap, loc As Coord)
        'imposta i parametri
        Me.X = loc.GetX
        Me.Y = loc.GetY
        Me.map = map
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di MapTile
    ''' </summary>
    ''' <param name="map">Mappa da usare</param>
    ''' <param name="loc">Locazione del MapTilr</param>
    Public Sub New(map As IMap, loc As ILocated)
        'imposta i parametri
        Me.X = loc.GetX
        Me.Y = loc.GetY
        Me.map = map
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di MapTile
    ''' </summary>
    ''' <param name="map">Mappa da usare</param>
    ''' <param name="locX">Locazione X del MapTilr</param>
    ''' <param name="locY">Locazione Y del MapTile</param>
    Public Sub New(map As IMap, locX As Integer, locY As Integer)
        'imposta i parametri
        Me.X = locX
        Me.Y = locY
        Me.map = map
    End Sub

    ''' <summary>
    ''' Restituisce la mappa di appartenenza
    ''' </summary>
    ''' <returns>Mappa</returns>
    Overridable Function GetMap() As IMap Implements IMapTile.GetMap
        'Restituisce la mappa
        Return map
    End Function
    ''' <summary>
    ''' Restituisce il tile sulla piastrella
    ''' </summary>
    ''' <returns>Il tile</returns>
    ''' <remarks>Se il tile è nothing viene restituito Default Tile di Map</remarks>
    Overridable Function GetTile() As ITile Implements IMapTile.GetTile
        'verifica che non sia nothing
        If HasTile() Then
            'restituisce il tile
            Return tile
        Else
            'restituise il tile di default
            Return map.GetDefaultTile
        End If
    End Function

    ''' <summary>
    ''' Imposta la piastrella sull' imapTile
    ''' </summary>
    ''' <param name="tile">Tile da impostare</param>
    ''' <remarks>Gli aggiornamenti e il lancio degli eventi vengono eseguiti automaticamente</remarks>
    Overridable Sub SetTile(tile As ITile) Implements IMapTile.SetTile
        'imposta il tile
        Me.tile = tile
    End Sub
    ''' <summary>
    ''' Imposta la piastrella sull' imaptile in modo insicuro
    ''' </summary>
    ''' <param name="tile">Tile da impostare</param>
    ''' <remarks>Gli eventi non vengono eseguiti</remarks>
    Overridable Sub SetUnsecureTile(tile As ITile) Implements IMapTile.SetUnsecureTile
        'imposta il tile in modo insicuro
        Me.tile = tile
    End Sub
    ''' <summary>
    ''' Rimuove il tile
    ''' </summary>
    ''' <remarks>Viene aggiornato la renderFlag e attivati gli eventi</remarks>
    Overridable Sub RemoveTile() Implements IMapTile.RemoveTile
        'rimuove il tile
        Me.tile = Nothing
    End Sub
    ''' <summary>
    ''' Rimuove il tile in modo insicuro
    ''' </summary>
    ''' <remarks>Non vengono aggiornati la renderFlag o attivati gli eventi</remarks>
    Overridable Sub RemoveUnsecureTile() Implements IMapTile.RemoveUnsecureTile
        'rimuove il tile
        Me.tile = Nothing
    End Sub

    ''' <summary>
    ''' Restituisce True se c'è un tile
    ''' </summary>
    ''' <returns>True il tile non è nothing</returns>
    Overridable Function HasTile() As Boolean Implements IMapTile.HasTile
        'restituisce true se non è nothing
        Return Not tile Is Nothing
    End Function

    ''' <summary>
    ''' Inizializza il mapTile e il tile
    ''' </summary>
    Overridable Sub Init() Implements IMapTile.Init
        'inizializza il tile
        GetTile().Init(Me)
    End Sub
    ''' <summary>
    ''' Aggiorna il tile
    ''' </summary>
    Overridable Sub UpdateTile() Implements IMapTile.UpdateTile
        'aggiorna il tile
        GetTile().Update(Me)
    End Sub

    ''' <summary>
    ''' Restituisce true se è presente un attore, altrimenti false
    ''' </summary>
    ''' <returns>True se è presente un attore, altrimenti false</returns>
    Overridable Function HasActor() As Boolean Implements IMapTile.HasActor
        'restituisce true se ha un attore
        Return Not act Is Nothing
    End Function

    ''' <summary>
    ''' Restituisce l'attore se ne è presente, altrimenti nothing
    ''' </summary>
    ''' <returns>Attore</returns>
    Function GetActor() As IActor Implements IMapTile.GetActor
        'restituisce l'attore
        Return act
    End Function
    ''' <summary>
    ''' Imposta l'attore in modo insicuro
    ''' </summary>
    ''' <param name="act">Attore da impostare</param>
    Overridable Sub SetActor(act As IActor) Implements IMapTile.SetActor
        'imposta l'attore
        Me.act = act
    End Sub
    ''' <summary>
    ''' Verifica se l'attore può spostarsi qui
    ''' </summary>
    ''' <param name="act">Attore da verificare</param>
    ''' <returns>True se può entrare, altrimenti false</returns>
    Public Overridable Function CanActorEnter(act As IActor) As Boolean Implements IMapTile.CanActorEnter
        'restituisce solo se è libero
        Return Not HasActor()
    End Function
End Class
