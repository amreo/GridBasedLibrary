''' <summary>
''' Rappresenta una mappa ottimizata per i client sul rendering
''' </summary>
Public Class HSMapTileClient
    Inherits HSMapTile
    Implements IMapTileClient

    ''' <summary>
    ''' Puntatore alla mappa client
    ''' </summary>
    Protected mapClient As IMapClient

    ''' <summary>
    ''' Crea una nuova istanza di MapTile
    ''' </summary>
    ''' <param name="map">Mappa da usare</param>
    ''' <param name="loc">Locazione del MapTilr</param>
    Public Sub New(map As IMapClient, loc As Coord)
        'imposta i parametri
        MyBase.New(map, loc)
        mapClient = map
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di MapTile
    ''' </summary>
    ''' <param name="map">Mappa da usare</param>
    ''' <param name="loc">Locazione del MapTilr</param>
    Public Sub New(map As IMapClient, loc As ILocated)
        'imposta i parametri
        MyBase.New(map, loc)
        mapClient = map
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di MapTile
    ''' </summary>
    ''' <param name="map">Mappa da usare</param>
    ''' <param name="locX">Locazione X del MapTilr</param>
    ''' <param name="locY">Locazione Y del MapTile</param>
    Public Sub New(map As IMapClient, locX As Integer, locY As Integer)
    'imposta i parametri
        MyBase.New(map, locX, locY)
        mapClient = map
    End Sub

    ''' <summary>
    ''' Restituisce true se deve essere renderizzato, altrimenti false
    ''' </summary>
    ''' <returns>True se deve essere re-renderizzato</returns>
    Public Function CanRenderFlag() As Boolean Implements IMapTileClient.CanRenderFlag
        'restituisce true se deve essere re-renderizzato
        Return mapClient.CanRenderUpdate(Me)
    End Function

    ''' <summary>
    ''' Restituisce la mappa client a cui appartiene questo tile
    ''' </summary>
    ''' <returns>La mappa</returns>
    Public Function GetMapClient() As IMapClient Implements IMapTileClient.GetMapClient
        'restituisce la mappa client
        Return mapClient
    End Function

    ''' <summary>
    ''' Rimuove la renderFlag
    ''' </summary>
    Public Overridable Sub RemoveRenderFlag() Implements IMapTileClient.RemoveRenderFlag
        'rimuove la render flag
        mapClient.RemoveRenderFlag(Me)
    End Sub
    ''' <summary>
    ''' Imposta la renderflag
    ''' </summary>
    Public Overridable Sub SetRenderFlag() Implements IMapTileClient.SetRenderFlag
        'imposta la renderflag
        mapClient.SetRenderFlag(Me)
    End Sub

    ''' <summary>
    ''' Rimuove in modo sicuro il tile della mappa
    ''' </summary>
    Public Overrides Sub RemoveTile()
        'verifica che il tile è diverso dal defaulttile
        If GetTile.IsRenderEqual(map.GetDefaultTile) Then Return
        'aggiorna il rendering con setRenderFlag
        mapClient.SetRenderFlag(Me)
    End Sub

    ''' <summary>
    ''' Imposta in modo sicuro il tile della mappa
    ''' </summary>
    Public Overrides Sub SetTile(tile As ITile)
        'verifica che il tile è diverso dal defaulttile
        If GetTile.IsRenderEqual(tile) Then Return
        'imposta il tile
        MyBase.SetTile(tile)
        'aggiorna il rendering con setRenderFlag
        mapClient.SetRenderFlag(Me)
    End Sub
End Class
