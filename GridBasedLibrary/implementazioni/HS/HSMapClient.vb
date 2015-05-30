''' <summary>
''' Rappresenta una mappa usata dal lato client
''' </summary>
Public Class HSMapClient
    Inherits HSMap
    Implements IMapClient, IEnumerable(Of Coord)

    ''' <summary>
    ''' Ottiene o imposta il selecter che contiene i punti da renderizzare
    ''' </summary>
    Protected RenderGrid As GridListCoordSelecter

    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <param name="width">Larghezza della mappa</param>
    ''' <param name="height">Altezza della mappa</param>
    Protected Sub New(ByVal x As Integer, y As Integer, width As UInteger, height As UInteger)
        'inizializza mybase
        MyBase.New(x, y, width, height)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(Me.region)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <param name="width">Larghezza della mappa</param>
    ''' <param name="height">Altezza della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Protected Sub New(ByVal x As Integer, y As Integer, width As UInteger, height As UInteger, defaultTile As ITile)
        'inizializza mybase
        MyBase.New(x, y, width, height, defaultTile)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(Me.region)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    Protected Sub New(c As Coord, size As Size)
        'inizializza mybase
        MyBase.New(c, size)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(Me.region)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Protected Sub New(c As Coord, size As Size, defaultTile As ITile)
        'inizializza mybase
        MyBase.New(c, size, defaultTile)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(Me.region)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    Protected Sub New(c As ILocated, size As Size)
        'inizializza mybase
        MyBase.New(c, size)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(Me.region)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Protected Sub New(c As ILocated, size As Size, defaultTile As ITile)
        'inizializza mybase
        MyBase.New(c, size, defaultTile)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(Me.region)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="reg">Regione della mappa</param>
    Protected Sub New(reg As Rectangle)
        'inizializza mybase
        MyBase.New(reg)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(Me.region)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="reg">Regione della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Protected Sub New(reg As Rectangle, defaultTile As ITile)
        'inizializza mybase
        MyBase.New(reg, defaultTile)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(Me.region)
    End Sub

    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <param name="width">Larghezza della mappa</param>
    ''' <param name="height">Altezza della mappa</param>
    Public Shared Function CreateHSMapClient(ByVal x As Integer, y As Integer, width As UInteger, height As UInteger) As HSMapClient
        'crea se stesso
        CreateHSMapClient = New HSMapClient(x, y, width, height)
        'cicla x e y per creare HSMapTile
        For y2 = y To y + height - 1
            For x2 = x To x + width - 1
                'imposta HSMapTile
                CreateHSMapClient.grid(x2, y2) = New HSMapTileClient(CreateHSMapClient, x2, y2)
                'imposta la render flag
                CreateHSMapClient.SetRenderFlag(x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <param name="width">Larghezza della mappa</param>
    ''' <param name="height">Altezza della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Public Shared Function CreateHSMapClient(ByVal x As Integer, y As Integer, width As UInteger, height As UInteger, defaultTile As ITile) As HSMapClient
        'crea se stesso
        CreateHSMapClient = New HSMapClient(x, y, width, height, defaultTile)
        'cicla x e y per creare HSMapTile
        For y2 = y To y + height - 1
            For x2 = x To x + width - 1
                'imposta HSMapTile
                CreateHSMapClient.grid(x2, y2) = New HSMapTileClient(CreateHSMapClient, x2, y2)
                CreateHSMapClient.grid(x2, y2).SetTile(defaultTile.GetIstance)
                'imposta la render flag
                CreateHSMapClient.SetRenderFlag(x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    Public Shared Function CreateHSMapClient(c As Coord, size As Size) As HSMapClient
        'crea se stesso
        CreateHSMapClient = New HSMapClient(c, size)
        'cicla x e y per creare HSMapTile
        For y2 = c.GetY To c.GetY + size.GetHeight - 1
            For x2 = c.GetX To c.GetX + size.GetWidth - 1
                'imposta HSMapTile
                CreateHSMapClient.grid(x2, y2) = New HSMapTileClient(CreateHSMapClient, x2, y2)
                'imposta la render flag
                CreateHSMapClient.SetRenderFlag(x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Public Shared Function CreateHSMapClient(c As Coord, size As Size, defaultTile As ITile) As HSMapClient
        'crea se stesso
        CreateHSMapClient = New HSMapClient(c, size, defaultTile)
        'cicla x e y per creare HSMapTile
        For y2 = c.GetY To c.GetY + size.GetHeight - 1
            For x2 = c.GetX To c.GetX + size.GetWidth - 1
                'imposta HSMapTile
                CreateHSMapClient.grid(x2, y2) = New HSMapTileClient(CreateHSMapClient, x2, y2)
                CreateHSMapClient.grid(x2, y2).SetTile(defaultTile.GetIstance)
                'imposta la render flag
                CreateHSMapClient.SetRenderFlag(x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    Public Shared Function CreateHSMapClient(c As ILocated, size As Size) As HSMapClient
        'crea se stesso
        CreateHSMapClient = New HSMapClient(c, size)
        'cicla x e y per creare HSMapTile
        For y2 = c.GetY To c.GetY + size.GetHeight - 1
            For x2 = c.GetX To c.GetX + size.GetWidth - 1
                'imposta HSMapTile
                CreateHSMapClient.grid(x2, y2) = New HSMapTileClient(CreateHSMapClient, x2, y2)
                'imposta la render flag
                CreateHSMapClient.SetRenderFlag(x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Public Shared Function CreateHSMapClient(c As ILocated, size As Size, defaultTile As ITile) As HSMapClient
        'crea se stesso
        CreateHSMapClient = New HSMapClient(c, size, defaultTile)
        'cicla x e y per creare HSMapTile
        For y2 = c.GetY To c.GetY + size.GetHeight - 1
            For x2 = c.GetX To c.GetX + size.GetWidth - 1
                'imposta HSMapTile
                CreateHSMapClient.grid(x2, y2) = New HSMapTileClient(CreateHSMapClient, x2, y2)
                CreateHSMapClient.grid(x2, y2).SetTile(defaultTile.GetIstance)
                'imposta la render flag
                CreateHSMapClient.SetRenderFlag(x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="reg">Regione della mappa</param>
    Public Shared Function CreateHSMapClient(reg As Rectangle) As HSMapClient
        'crea se stesso
        CreateHSMapClient = New HSMapClient(reg)
        'cicla x e y per creare HSMapTile
        For y2 = reg.GetY To reg.GetY + reg.GetHeight - 1
            For x2 = reg.GetX To reg.GetX + reg.GetWidth - 1
                'imposta HSMapTile
                CreateHSMapClient.grid(x2, y2) = New HSMapTileClient(CreateHSMapClient, x2, y2)
                'imposta la render flag
                CreateHSMapClient.SetRenderFlag(x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="reg">Regione della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Public Shared Function CreateHSMapClient(reg As Rectangle, defaultTile As ITile) As HSMapClient
        'crea se stesso
        CreateHSMapClient = New HSMapClient(reg, defaultTile)
        'cicla x e y per creare HSMapTile
        For y2 = reg.GetY To reg.GetY + reg.GetHeight - 1
            For x2 = reg.GetX To reg.GetX + reg.GetWidth - 1
                'imposta HSMapTile
                CreateHSMapClient.grid(x2, y2) = New HSMapTileClient(CreateHSMapClient, x2, y2)
                CreateHSMapClient.grid(x2, y2).SetTile(defaultTile.GetIstance)
                'imposta la render flag
                CreateHSMapClient.SetRenderFlag(x2, y2)
            Next
        Next
    End Function

    ''' <summary>
    ''' Restituisce true se c deve essere renderizzato
    ''' </summary>
    ''' <param name="c">Cordinata da verificare</param>
    ''' <returns>True se deve essere re-renderizzato</returns>
    Public Overridable Function CanRenderUpdate(c As ILocated) As Boolean Implements IMapClient.CanRenderUpdate
        'esegue la verifica e restituisce il valore
        Return RenderGrid.IsSelected(c)
    End Function
    ''' <summary>
    ''' Restituisce true se c deve essere renderizzato
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <returns>True se deve essere re-renderizzato</returns>
    Public Overridable Function CanRenderUpdate(x As Integer, y As Integer) As Boolean Implements IMapClient.CanRenderUpdate
        'esegue la verifica e restituisce il valore
        Return RenderGrid.IsSelected(x, y)
    End Function

    ''' <summary>
    ''' Restituisce le cordinata da renderizzaare
    ''' </summary>
    ''' <returns>Cordinate da renderizzare</returns>
    Public Function GetRenderUpdateCoords() As Coord() Implements IMapClient.GetRenderUpdateCoords
        'restituisce l'elenco
        Return RenderGrid.GetSelection
    End Function

    ''' <summary>
    ''' Rimuove la renderflag dalla cordinata
    ''' </summary>
    ''' <param name="c">Cordinata di cui rimuovere la renderflag</param>
    Public Overridable Sub RemoveRenderFlag(c As ILocated) Implements IMapClient.RemoveRenderFlag
        'rimuove la renderflag
        RenderGrid.DeSelect(c)
    End Sub
    ''' <summary>
    ''' Rimuove la renderflag dalla cordinate
    ''' </summary>
    ''' <param name="c">Cordinate di cui rimuovere la renderflag</param>
    Public Overridable Sub RemoveRenderFlag(ParamArray c() As ILocated) Implements IMapClient.RemoveRenderFlag
        'rimuove la renderflag
        For Each item As ILocated In c
            RemoveRenderFlag(item)
        Next
    End Sub
    ''' <summary>
    ''' Rimuove la renderflag dalla cordinata
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    Public Overridable Sub RemoveRenderFlag(x As Integer, y As Integer) Implements IMapClient.RemoveRenderFlag
        'rimuove la renderflag
        RenderGrid.DeSelect(x, y)
    End Sub

    ''' <summary>
    ''' Imposta la render flag
    ''' </summary>
    ''' <param name="c">Cordinata da renderizzare</param>
    Public Overridable Sub SetRenderFlag(c As ILocated) Implements IMapClient.SetRenderFlag
        'imposta la renderflag
        RenderGrid.Select(c)
    End Sub
    ''' <summary>
    ''' Imposta la render flag
    ''' </summary>
    ''' <param name="c">Cordinate da renderizzare</param>
    Public Overridable Sub SetRenderFlag(ParamArray c() As ILocated) Implements IMapClient.SetRenderFlag
        'imposta la renderflag
        For Each item As ILocated In c
            SetRenderFlag(item)
        Next
    End Sub
    ''' <summary>
    ''' Imposta la render flag
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    Public Overridable Sub SetRenderFlag(x As Integer, y As Integer) Implements IMapClient.SetRenderFlag
        'imposta la renderflag
        RenderGrid.Select(x, y)
    End Sub

    ''' <summary>
    ''' Verifica che dal punto di vista del rendering sono uguali
    ''' </summary>
    ''' <param name="MapTile1">Primo MapTile</param>
    ''' <param name="MapTile2">Secondo MapTile</param>
    ''' <returns>True se sono uguali</returns>
    Public Overridable Function IsRenderEqual(MapTile1 As HSMapTileClient, MapTile2 As HSMapTileClient)
        'verifica che sono uguali dal punto di vista del renderer
        Return MapTile1.GetTile().IsRenderEqual(MapTile2.GetTile) And Not MapTile1.HasActor() And Not MapTile2.HasActor()
    End Function

    ''' <summary>
    ''' Restituisce l'enumeratore dell'elenco di tile da renderizzare
    ''' </summary>
    ''' <returns>Enumeratore dell'elenco di tile da renderizzare</returns>
    Public Function GetEnumerator() As IEnumerator(Of Coord) Implements IEnumerable(Of Coord).GetEnumerator
        'restituisce l'enumeratore
        Return RenderGrid.GetEnumerator
    End Function
    ''' <summary>
    ''' Restituisce l'enumeratore dell'elenco di tile da renderizzare
    ''' </summary>
    ''' <returns>Enumeratore dell'elenco di tile da renderizzare</returns>
    Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        'restituisce l'enumeratore
        Return RenderGrid.GetEnumerator
    End Function

    ''' <summary>
    ''' Viene notificato a IMap che l'attore ha cambiato posizione
    ''' </summary>
    ''' <param name="act">Attore che si è spostato</param>
    ''' <param name="src">Sorgente</param>
    ''' <param name="dest">Destinazione</param>
    Public Overrides Sub NotifyChange(act As IActor, src As IMapTile, dest As IMapTile)
        'notifa alla classe base
        MyBase.NotifyChange(act, src, dest)
        'viene attivata la flag per il rendering di src e dest
        If Not src Is Nothing Then SetRenderFlag(src)
        If Not dest Is Nothing Then SetRenderFlag(dest)
    End Sub
End Class
