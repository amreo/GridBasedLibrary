''' <summary>
''' Rappresenta un mapclient con uno schermo
''' </summary>
Public Class HSMapClientWithScreen
    Inherits HSMapClient
    Implements IMovable

    ''' <summary>
    ''' Cordinate dello screen
    ''' </summary>
    Protected ScreenC As Coord

    ''' <summary>
    ''' Ottiene o imposta le dimensioni dello screen
    ''' </summary>
    Protected screenSize As Size


    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <param name="width">Larghezza della mappa</param>
    ''' <param name="height">Altezza della mappa</param>
    Protected Sub New(ByVal x As Integer, y As Integer, width As UInteger, height As UInteger, xScreen As Integer, yScreen As Integer, widthScreen As Integer, heightScreen As Integer)

        'inizializza mybase
        MyBase.New(x, y, width, height)
        'imposta lo screen
        ScreenC = New Coord(xScreen, yScreen)
        screenSize = New Size(widthScreen, heightScreen)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(0, 0, widthScreen, heightScreen)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <param name="width">Larghezza della mappa</param>
    ''' <param name="height">Altezza della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Protected Sub New(ByVal x As Integer, y As Integer, width As UInteger, height As UInteger, defaultTile As ITile, xScreen As Integer, yScreen As Integer, widthScreen As Integer, heightScreen As Integer)
        'inizializza mybase
        MyBase.New(x, y, width, height, defaultTile)
        'imposta lo screen
            ScreenC = New Coord(xScreen, yScreen)
        screenSize = New Size(widthScreen, heightScreen)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(0, 0, widthScreen, heightScreen)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    Protected Sub New(c As Coord, size As Size, cScreen As Coord, sizeScreen As Size)
        'inizializza mybase
        MyBase.New(c, size)
        'imposta lo screen
        ScreenC = cScreen
        screenSize = New Size(sizeScreen.GetWidth, sizeScreen.GetHeight)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(New Coord(0, 0), sizeScreen)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Protected Sub New(c As Coord, size As Size, defaultTile As ITile, cScreen As Coord, sizeScreen As Size)
        'inizializza mybase
        MyBase.New(c, size, defaultTile)
        'imposta lo screen
        ScreenC = cScreen
        screenSize = New Size(sizeScreen.GetWidth, sizeScreen.GetHeight)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(New Coord(0, 0), sizeScreen)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    Protected Sub New(c As ILocated, size As Size, cScreen As ILocated, sizeScreen As Size)
        'inizializza mybase
        MyBase.New(c, size)
        'imposta lo screen
        ScreenC = cScreen
        screenSize = New Size(sizeScreen.GetWidth, sizeScreen.GetHeight)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(New Coord(0, 0), sizeScreen)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Protected Sub New(c As ILocated, size As Size, defaultTile As ITile, cScreen As ILocated, sizeScreen As Size)
        'inizializza mybase
        MyBase.New(c, size, defaultTile)
        'imposta lo screen
        ScreenC = cScreen
        screenSize = New Size(sizeScreen.GetWidth, sizeScreen.GetHeight)
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(New Coord(0, 0), sizeScreen)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="reg">Regione della mappa</param>
    Protected Sub New(reg As Rectangle, screen As Rectangle)
        'inizializza mybase
        MyBase.New(reg)
        'imposta lo screen
        ScreenC = screen.GetLocation
        screenSize = screen.GetSize
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(New Coord(0, 0), screen.GetSize)
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="reg">Regione della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Protected Sub New(reg As Rectangle, defaultTile As ITile, screen As Rectangle)
        'inizializza mybase
        MyBase.New(reg, defaultTile)
        'imposta lo screen
        ScreenC = screen.GetLocation
        screenSize = screen.GetSize
        'istanzia rendergrid
        RenderGrid = New GridListCoordSelecter(New Coord(0, 0), screen.GetSize)
    End Sub

    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <param name="width">Larghezza della mappa</param>
    ''' <param name="height">Altezza della mappa</param>
    Public Shared Function CreateHSMapClientWithScreen(ByVal x As Integer, y As Integer, width As UInteger, height As UInteger, xScreen As Integer, yScreen As Integer, widthScreen As Integer, heightScreen As Integer) As HSMapClientWithScreen
        'crea se stesso
        CreateHSMapClientWithScreen = New HSMapClientWithScreen(x, y, width, height, xScreen, yScreen, widthScreen, heightScreen)
        'cicla x e y per creare HSMapTile
        For y2 = y To y + height - 1
            For x2 = x To x + width - 1
                'imposta HSMapTile
                CreateHSMapClientWithScreen.grid(x2, y2) = New HSMapTileClient(CreateHSMapClientWithScreen, x2, y2)
                'imposta la render flag
                CreateHSMapClientWithScreen.SetRenderFlag(x2, y2)
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
    Public Shared Function CreateHSMapClientWithScreen(ByVal x As Integer, y As Integer, width As UInteger, height As UInteger, defaultTile As ITile, xScreen As Integer, yScreen As Integer, widthScreen As Integer, heightScreen As Integer) As HSMapClientWithScreen
        'crea se stesso
        CreateHSMapClientWithScreen = New HSMapClientWithScreen(x, y, width, height, defaultTile, xScreen, yScreen, widthScreen, heightScreen)
        'cicla x e y per creare HSMapTile
        For y2 = y To y + height - 1
            For x2 = x To x + width - 1
                'imposta HSMapTile
                CreateHSMapClientWithScreen.grid(x2, y2) = New HSMapTileClient(CreateHSMapClientWithScreen, x2, y2)
                CreateHSMapClientWithScreen.grid(x2, y2).SetTile(defaultTile.GetIstance)
                'imposta la render flag
                CreateHSMapClientWithScreen.SetRenderFlag(x2, y2)
            Next
        Next


    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    Public Shared Function CreateHSMapClientWithScreen(c As Coord, size As Size, cScreen As Coord, sizeScreen As Size) As HSMapClientWithScreen
        'crea se stesso
        CreateHSMapClientWithScreen = New HSMapClientWithScreen(c, size, cScreen, sizeScreen)
        'cicla x e y per creare HSMapTile
        For y2 = c.GetY To c.GetY + size.GetHeight - 1
            For x2 = c.GetX To c.GetX + size.GetWidth - 1
                'imposta HSMapTile
                CreateHSMapClientWithScreen.grid(x2, y2) = New HSMapTileClient(CreateHSMapClientWithScreen, x2, y2)
                'imposta la render flag
                CreateHSMapClientWithScreen.SetRenderFlag(x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Public Shared Function CreateHSMapClientWithScreen(c As Coord, size As Size, defaultTile As ITile, cScreen As Coord, sizeScreen As Size) As HSMapClientWithScreen
        'crea se stesso
        CreateHSMapClientWithScreen = New HSMapClientWithScreen(c, size, defaultTile, cScreen, sizeScreen)
        'cicla x e y per creare HSMapTile
        For y2 = c.GetY To c.GetY + size.GetHeight - 1
            For x2 = c.GetX To c.GetX + size.GetWidth - 1
                'imposta HSMapTile
                CreateHSMapClientWithScreen.grid(x2, y2) = New HSMapTileClient(CreateHSMapClientWithScreen, x2, y2)
                CreateHSMapClientWithScreen.grid(x2, y2).SetTile(defaultTile.GetIstance)
                'imposta la render flag
                CreateHSMapClientWithScreen.SetRenderFlag(x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    Public Shared Function CreateHSMapClientWithScreen(c As ILocated, size As Size, cScreen As ILocated, sizeScreen As Size) As HSMapClientWithScreen
        'crea se stesso
        CreateHSMapClientWithScreen = New HSMapClientWithScreen(c, size, cScreen, sizeScreen)
        'cicla x e y per creare HSMapTile
        For y2 = c.GetY To c.GetY + size.GetHeight - 1
            For x2 = c.GetX To c.GetX + size.GetWidth - 1
                'imposta HSMapTile
                CreateHSMapClientWithScreen.grid(x2, y2) = New HSMapTileClient(CreateHSMapClientWithScreen, x2, y2)
                'imposta la render flag
                CreateHSMapClientWithScreen.SetRenderFlag(x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="c">Cordinata della mappa</param>
    ''' <param name="size">Dimensioni della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Public Shared Function CreateHSMapClientWithScreen(c As ILocated, size As Size, defaultTile As ITile, cScreen As ILocated, sizeScreen As Size) As HSMapClientWithScreen
        'crea se stesso
        CreateHSMapClientWithScreen = New HSMapClientWithScreen(c, size, defaultTile, cScreen, sizeScreen)
        'cicla x e y per creare HSMapTile
        For y2 = c.GetY To c.GetY + size.GetHeight - 1
            For x2 = c.GetX To c.GetX + size.GetWidth - 1
                'imposta HSMapTile
                CreateHSMapClientWithScreen.grid(x2, y2) = New HSMapTileClient(CreateHSMapClientWithScreen, x2, y2)
                CreateHSMapClientWithScreen.grid(x2, y2).SetTile(defaultTile.GetIstance)
                'imposta la render flag
                CreateHSMapClientWithScreen.SetRenderFlag(x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="reg">Regione della mappa</param>
    Public Shared Function CreateHSMapClientWithScreen(reg As Rectangle, screen As Rectangle) As HSMapClientWithScreen
        'crea se stesso
        CreateHSMapClientWithScreen = New HSMapClientWithScreen(reg, screen)
        'cicla x e y per creare HSMapTile
        For y2 = reg.GetY To reg.GetY + reg.GetHeight - 1
            For x2 = reg.GetX To reg.GetX + reg.GetWidth - 1
                'imposta HSMapTile
                CreateHSMapClientWithScreen.grid(x2, y2) = New HSMapTileClient(CreateHSMapClientWithScreen, x2, y2)
                'imposta la render flag
                CreateHSMapClientWithScreen.SetRenderFlag(x2, y2)
            Next
        Next
    End Function
    ''' <summary>
    ''' Crea una nuova istanza di HSMap
    ''' </summary>
    ''' <param name="reg">Regione della mappa</param>
    ''' <param name="defaultTile">Tile di default</param>
    Public Shared Function CreateHSMapClientWithScreen(reg As Rectangle, defaultTile As ITile, screen As Rectangle) As HSMapClientWithScreen
        'crea se stesso
        CreateHSMapClientWithScreen = New HSMapClientWithScreen(reg, defaultTile, screen)
        'cicla x e y per creare HSMapTile
        For y2 = reg.GetY To reg.GetY + reg.GetHeight - 1
            For x2 = reg.GetX To reg.GetX + reg.GetWidth - 1
                'imposta HSMapTile
                CreateHSMapClientWithScreen.grid(x2, y2) = New HSMapTileClient(CreateHSMapClientWithScreen, x2, y2)
                CreateHSMapClientWithScreen.grid(x2, y2).SetTile(defaultTile.GetIstance)
                'imposta la render flag
                CreateHSMapClientWithScreen.SetRenderFlag(x2, y2)
            Next
        Next
    End Function

    ''' <summary>
    ''' Ottiene la larghezza dello screen
    ''' </summary>
    ''' <returns>La larghezza</returns>
    Public Function GetScreenWidth() As UInteger
        'restituisce Width
        Return screenSize.GetWidth
    End Function
    ''' <summary>
    ''' Ottiene l'altezza dello screen
    ''' </summary>
    ''' <returns>L'altezza</returns>
    Public Function GetScreenHeight() As UInteger
        'restituisce height
        Return screenSize.GetHeight
    End Function
    ''' <summary>
    ''' Ottiene il valore di size usato nelle serializzazioni
    ''' </summary>
    ''' <returns>Il valore di size</returns>
    ''' <remarks>E' usato solo nelle serializzazioni</remarks>
    Public Function GetScreenSizeValue() As ULong
        'restituisce il valore calcolandolo
        Return CLng(screenSize.GetWidth) << 32 Or screenSize.GetHeight
    End Function

    ''' <summary>
    ''' Ottiene la  cordinata spostata di 1 da direction
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    ''' <returns>Cordinata spostata di 1</returns>
    Public Function GetScreenCoordByDirection(direction As Direction) As Coord Implements ILocated.GetCoordByDirection
        'restituisce lo spostamento
        Return ScreenC.GetCoordByDirection(direction)
    End Function
    ''' <summary>
    ''' Ottiene la  cordinata spostata di 1 da direction
    ''' </summary>
    ''' <param name="direction">Direzione</param>
    ''' <param name="offset">Offset</param>
    ''' <returns>Cordinata spostata di 1</returns>
    Public Function GetScreenCoordByDirection(direction As Direction, offset As Integer) As Coord Implements ILocated.GetCoordByDirection
        'restituisce lo spostamento
        Return ScreenC.GetCoordByDirection(direction, offset)
    End Function
    ''' <summary>
    ''' Ottiene la  cordinata spostata di offx e offy
    ''' </summary>
    ''' <param name="offx">Offset X</param>
    ''' <param name="offy">Offset Y</param>
    ''' <returns>Cordinata spostata di 1</returns>
    Public Function GetScreenCoordByOffset(offx As Integer, offy As Integer) As Coord Implements ILocated.GetCoordByOffset
        'restituisce lo spostamento
        Return ScreenC.GetCoordByOffset(offx, offy)
    End Function

    ''' <summary>
    ''' Ottiene la cordinata spostata di 1 verso giù
    ''' </summary>
    ''' <returns>Cordinata spostata di 1 verso giù</returns>
    Public Function GetScreenDown() As Coord Implements ILocated.GetDown
        'restituisce lo spostamento
        Return ScreenC.GetDown()
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di off verso giù
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    ''' <returns>Cordinata spostata di 1 verso giù</returns>
    Public Function GetScreenDown(offset As Integer) As Coord Implements ILocated.GetDown
        'restituisce lo spostamento
        Return ScreenC.GetDown(offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di 1 verso sx
    ''' </summary>
    ''' <returns>Cordinata spostata di 1 verso sx</returns>
    Public Function GetScreenLeft() As Coord Implements ILocated.GetLeft
        'restituisce lo spostamento
        Return ScreenC.GetLeft()
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di off verso sx
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    ''' <returns>Cordinata spostata di off verso sx</returns>
    Public Function GetScreenLeft(offset As Integer) As Coord Implements ILocated.GetLeft
        'restituisce lo spostamento
        Return ScreenC.GetLeft(offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di 1 verso sx-giù
    ''' </summary>
    ''' <returns>Cordinata spostata di 1 verso sx-giù</returns>
    Public Function GetScreenLeftDown() As Coord Implements ILocated.GetLeftDown
        'restituisce lo spostamento
        Return ScreenC.GetLeftDown()
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di off verso sx-giù
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    ''' <returns>Cordinata spostata di off verso sx-giù</returns>
    Public Function GetScreenLeftDown(offset As Integer) As Coord Implements ILocated.GetLeftDown
        'restituisce lo spostamento
        Return ScreenC.GetLeftDown(offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di 1 verso sx-su
    ''' </summary>
    ''' <returns>Cordinata spostata di 1 verso sx-su</returns>
    Public Function GetScreenLeftUp() As Coord Implements ILocated.GetLeftUp
        'restituisce lo spostamento
        Return ScreenC.GetLeftUp()
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di off verso sx-su
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    ''' <returns>Cordinata spostata di off verso sx-su</returns>
    Public Function GetScreenLeftUp(offset As Integer) As Coord Implements ILocated.GetLeftUp
        'restituisce lo spostamento
        Return ScreenC.GetLeftUp(offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di 1 verso dx
    ''' </summary>
    ''' <returns>Cordinata spostata di 1 verso dx</returns>
    Public Function GetScreenRight() As Coord Implements ILocated.GetRight
        'restituisce lo spostamento
        Return ScreenC.GetRight()
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di off verso dx
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    ''' <returns>Cordinata spostata di off verso dx</returns>
    Public Function GetScreenRight(offset As Integer) As Coord Implements ILocated.GetRight
        'restituisce lo spostamento
        Return ScreenC.GetRight(offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di 1 verso dx-giù
    ''' </summary>
    ''' <returns>Cordinata spostata di 1 verso dx-giù</returns>
    Public Function GetScreenRightDown() As Coord Implements ILocated.GetRightDown
        'restituisce lo spostamento
        Return ScreenC.GetRightDown()
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di off verso dx-giù
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    ''' <returns>Cordinata spostata di off verso dx-giù</returns>
    Public Function GetScreenRightDown(offset As Integer) As Coord Implements ILocated.GetRightDown
        'restituisce lo spostamento
        Return ScreenC.GetRightDown(offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di 1 verso dx-su
    ''' </summary>
    ''' <returns>Cordinata spostata di 1 verso dx-su</returns>
    Public Function GetRightUp() As Coord Implements ILocated.GetRightUp
        'restituisce lo spostamento
        Return ScreenC.GetRightUp()
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di off verso dx-su
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    ''' <returns>Cordinata spostata di off verso dx-su</returns>
    Public Function GetScreenRightUp(offset As Integer) As Coord Implements ILocated.GetRightUp
        'restituisce lo spostamento
        Return ScreenC.GetRightUp(offset)
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di 1 verso su
    ''' </summary>
    ''' <returns>Cordinata spostata di 1 verso su</returns>
    Public Function GetScreenUp() As Coord Implements ILocated.GetUp
        'restituisce lo spostamento
        Return ScreenC.GetUp()
    End Function
    ''' <summary>
    ''' Ottiene la cordinata spostata di off verso su
    ''' </summary>
    ''' <returns>Cordinata spostata di off verso su</returns>
    Public Function GetScreenUp(offset As Integer) As Coord Implements ILocated.GetUp
        'restituisce lo spostamento
        Return ScreenC.GetUp(offset)
    End Function

    ''' <summary>
    ''' Restituisce la cordinata X
    ''' </summary>
    ''' <returns>Cordinata X</returns>
    ''' <remarks></remarks>
    Public Function GetScreenX() As Integer Implements ILocated.GetX
        'restituisce lo spostamento
        Return ScreenC.GetX()
    End Function
    ''' <summary>
    ''' Restituisce la cordinata y
    ''' </summary>
    ''' <returns>Cordinata Y</returns>
    Public Function GetScreenY() As Integer Implements ILocated.GetY
        'restituisce lo spostamento
        Return ScreenC.GetY()
    End Function

    ''' <summary>
    ''' Restituisce la locazione dello screen
    ''' </summary>
    ''' <returns>La Locazione dello screen</returns>
    Public Function GetScreenLocation() As Coord Implements ILocated.GetLocation
        'restituisce lo spostamento
        Return ScreenC
    End Function
    ''' <summary>
    ''' Restituisce il valore della locazione dello screen
    ''' </summary>
    ''' <returns>Il valore della Locazione dello screen</returns>
    ''' <remarks>è utile solamente nella serializzazione</remarks>
    Public Function GetScreenLocationValue() As ULong Implements ILocated.GetLocationValue
        'restituisce lo spostamento
        Return ScreenC.GetLocationValue
    End Function

    ''' <summary>
    ''' Sposta lo screen verso direzione di 1
    ''' </summary>
    ''' <param name="direction">Direzione di spostamento</param>
    Public Sub MoveScreenByDirection(direction As Direction) Implements IMovable.MoveByDirection
        'sposta lo screenC
        MoveScreenByOffset(1 * direction.GetCoefficientX, 1 * direction.GetCoefficientY)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso direzione di 1
    ''' </summary>
    ''' <param name="direction">Direzione di spostamento</param>
    ''' <param name="offset">Offset di spostamento</param>
    Public Sub MoveScreenByDirection(direction As Direction, offset As Integer) Implements IMovable.MoveByDirection
        'sposta lo screenC
        MoveScreenByOffset(offset * direction.GetCoefficientX, offset * direction.GetCoefficientY)
    End Sub
    ''' <summary>
    ''' Sposta lo screen di offx e offy
    ''' </summary>
    ''' <param name="offx">Offset X</param>
    ''' <param name="offy">Offset Y</param>
    Public Overridable Sub MoveScreenByOffset(offx As Integer, offy As Integer) Implements IMovable.MoveByOffset
        'offx e offy sono entrambi deltaX e deltaY
        'corregge entrambi i delta/offset
        'controlla se esce fuori dal lato sx
        If ScreenC.GetX() + offx < region.GetX Then offx = -ScreenC.GetX() 'formula matematica: offx + ScreenC.getX() = -ScreenC.getX + Screen.getX = 0
        'stessa cosa col lato su
        If ScreenC.GetY() + offy < region.GetY Then offy = -ScreenC.GetY() 'formula matematica: offy + ScreenC.getY() = -ScreenC.getY + Screen.getY = 0	
        'verifica che non esce dai bordi superiori
        'lato dx e giù
        If (ScreenC.GetX() + screenSize.GetWidth - 1) + offx >= region.GetX + region.GetWidth Then offx = region.GetWidth() - screenSize.GetWidth() - ScreenC.GetX() + region.GetX
        If (ScreenC.GetY() + screenSize.GetHeight - 1) + offy >= region.GetY + region.GetHeight Then offy = region.GetHeight() - screenSize.GetHeight() - ScreenC.GetY() + region.GetY
        'NB con x e y si riferisce alla mappa
        'verificano che durante la correzione gli offset non sono diventati 0
        If offx = 0 And offy = 0 Then Return
        'dopo aver corretto gli offset applica l'offset
        ScreenC.MoveByOffset(offx, offy)
        'aggiorna le render flag delle zone spostate
        'sfasa di offx e offy le precedente selezioni non re-renderizzate
        Dim c() As Coord = GetRenderUpdateCoords()
        'cancella gli elementi
        RenderGrid.DeSelectAll()
        'sfasa ogni cordinata
        For Each item As Coord In c
            'riseleziona la cordinata sfasata
            RenderGrid.Select(item.GetX - offx, item.GetY - offy)
        Next
        'controlla x e y di ogni punto dello screen
        For x2 = ScreenC.GetX() To ScreenC.GetX() + screenSize.GetWidth() - 1
            For y2 = ScreenC.GetY() To ScreenC.GetY() + screenSize.GetHeight() - 1
                'verifica che sono uguali dal punto di vista del render
                If Not IsRenderEqual(GetMapTile(x2, y2), GetMapTile(x2 - offx, y2 - offy)) Then
                    SetRenderFlag(x2, y2)
                End If
            Next
        Next
    End Sub

    ''' <summary>
    ''' Sposta lo screen verso giù
    ''' </summary>
    Public Sub MoveScreenDown() Implements IMovable.MoveDown
        'sposta lo screen verso la direzione
        MoveScreenByOffset(0, 1)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso giù di off
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    Public Sub MoveScreenDown(offset As Integer) Implements IMovable.MoveDown
        'sposta lo screen verso la direzione
        MoveScreenByOffset(0, offset)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso sx
    ''' </summary>
    Public Sub MoveScreenLeft() Implements IMovable.MoveLeft
        'sposta lo screen verso la direzione
        MoveScreenByOffset(-1, 0)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso sx di off
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    Public Sub MoveScreenLeft(offset As Integer) Implements IMovable.MoveLeft
        'sposta lo screen verso la direzione
        MoveScreenByOffset(-offset, 0)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso sx-giù
    ''' </summary>
    Public Sub MoveScreenLeftDown() Implements IMovable.MoveLeftDown
        'sposta lo screen verso la direzione
        MoveScreenByOffset(-1, 1)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso sx-giù di offset
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    Public Sub MoveScreenLeftDown(offset As Integer) Implements IMovable.MoveLeftDown
        'sposta lo screen verso la direzione
        MoveScreenByOffset(-offset, offset)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso sx-su
    ''' </summary>
    Public Sub MoveScreenLeftUp() Implements IMovable.MoveLeftUp
        'sposta lo screen verso la direzione
        MoveScreenByOffset(-1, -1)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso sx-su di off
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    Public Sub MoveScreenLeftUp(offset As Integer) Implements IMovable.MoveLeftUp
        'sposta lo screen verso la direzione
        MoveScreenByOffset(-offset, -offset)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso dx
    ''' </summary>
    Public Sub MoveScreenRight() Implements IMovable.MoveRight
        'sposta lo screen verso la direzione
        MoveScreenByOffset(1, 0)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso dx di off
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    Public Sub MoveScreenRight(offset As Integer) Implements IMovable.MoveRight
        'sposta lo screen verso la direzione
        MoveScreenByOffset(offset, 0)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso dx-giù
    ''' </summary>
    Public Sub MoveScreenRightDown() Implements IMovable.MoveRightDown
        'sposta lo screen verso la direzione
        MoveScreenByOffset(1, 1)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso dx-giù di off
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    Public Sub MoveScreenRightDown(offset As Integer) Implements IMovable.MoveRightDown
        'sposta lo screen verso la direzione
        MoveScreenByOffset(offset, offset)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso dx-su
    ''' </summary>
    Public Sub MoveScreenRightUp() Implements IMovable.MoveRightUp
        'sposta lo screen verso la direzione
        MoveScreenByOffset(1, -1)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso dx-su di off
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    Public Sub MoveScreenRightUp(offset As Integer) Implements IMovable.MoveRightUp
        'sposta lo screen verso la direzione
        MoveScreenByOffset(1, -1)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso su
    ''' </summary>
    Public Sub MoveScreenUp() Implements IMovable.MoveUp
        'sposta lo screen verso la direzione
        MoveScreenByOffset(0, -1)
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso su
    ''' </summary>
    ''' <param name="offset">Offset di spostamento</param>
    Public Sub MoveScreenUp(offset As Integer) Implements IMovable.MoveUp
        'sposta lo screen verso la direzione
        MoveScreenByOffset(0, -offset)
    End Sub


    ''' <summary>
    ''' Sposta lo screen verso dest
    ''' </summary>
    ''' <param name="dest">destinazione di spostamento</param>
    Public Sub MoveScreenTo(dest As ILocated) Implements IMovable.MoveTo
        'sposta lo screenC
        MoveScreenByOffset(dest.GetX - GetScreenX(), dest.GetY - GetScreenY())
    End Sub
    ''' <summary>
    ''' Sposta lo screen verso dest
    ''' </summary>
    ''' <param name="destX">Cordinata X di spostamento</param>
    Public Sub MoveScreenTo(destX As Integer, destY As Integer) Implements IMovable.MoveTo
        'sposta lo screenC
        MoveScreenByOffset(destX - GetScreenX(), destY - GetScreenY())
    End Sub


    ''' <summary>
    ''' Imposta la cordinata 
    ''' </summary>
    ''' <param name="c">Cordinata da impostare</param>
    ''' <remarks>Sono simili a moveTo() ma non effetuano controllo sui bordi</remarks>
    Public Sub SetScreenLocation(c As ILocated) Implements IMovable.Set
        'imposta la cordinata
        ScreenC.Set(c)
    End Sub
    ''' <summary>
    ''' Imposta la cordinata 
    ''' </summary>
    ''' <param name="x">Cordinata X</param>
    ''' <param name="y">Cordinata Y</param>
    ''' <remarks>Sono simili a moveTo() ma non effetuano controllo sui bordi</remarks>
    Public Sub SetScreenLocation(x As Integer, y As Integer) Implements IMovable.Set
        'imposta la cordinata
        ScreenC.Set(x, y)
    End Sub
    ''' <summary>
    ''' Imposta la cordinata X
    ''' </summary>
    ''' <param name="value">Nuova cordinata X</param>
    ''' <remarks>Come la famiglia [Set]() non effettuano alcuno controlli sui bordi</remarks>
    Public Sub SetScreenX(value As Integer) Implements IMovable.SetX
        'imposta la cordinata X
        ScreenC.SetX(value)
    End Sub
    ''' <summary>
    ''' Imposta la cordinata Y
    ''' </summary>
    ''' <param name="value">Nuova cordinata Y</param>
    ''' <remarks>Come la famiglia [Set]() non effettuano alcuno controlli sui bordi</remarks>
    Public Sub SetScreenY(value As Integer) Implements IMovable.SetY
        'Imposta la cordinata Y
        ScreenC.SetY(value)
    End Sub

    ''' <summary>
    ''' Verifica che è da re-renderizzare la cordinata 
    ''' </summary>
    ''' <param name="c">Cordinata da verificare</param>
    ''' <returns>True se deve essere re-renderizzata</returns>
    ''' <remarks>Gli offset dello screen vengono scalati automaticamente</remarks>
    Public Overrides Function CanRenderUpdate(c As ILocated) As Boolean
        'restituisce la verifica
        Return RenderGrid.IsSelected(c.GetX - GetScreenX(), c.GetY - GetScreenY())
    End Function
    ''' <summary>
    ''' Verifica che è da re-renderizzare la cordinata 
    ''' </summary>
    ''' <param name="x">Cordinata x</param>
    ''' <param name="y">Cordinata y</param>
    ''' <returns>True se deve essere re-renderizzata</returns>
    ''' <remarks>Gli offset dello screen vengono scalati automaticamente</remarks>
    Public Overrides Function CanRenderUpdate(x As Integer, y As Integer) As Boolean
        'restituisce la verifica
        Return RenderGrid.IsSelected(x - GetScreenX(), y - GetScreenY())
    End Function

    ''' <summary>
    ''' Imposta la renderflag al tile
    ''' </summary>
    ''' <param name="c">Cordinata di cui impostare la renderflag</param>
    ''' <remarks>Gli offset dello screen vengono scalati automaticamente</remarks>
    Public Overrides Sub SetRenderFlag(c As ILocated)
        'imposta la render flag
        RenderGrid.Select(c.GetX - GetScreenX(), c.GetY - GetScreenY())
    End Sub
    ''' <summary>
    ''' Imposta la renderflag al tile
    ''' </summary>
    ''' <param name="x">Cordinata X di cui impostare la renderflag</param>
    ''' <param name="y">Cordinata Y di cui impostare la renderflag</param>
    ''' <remarks>Gli offset dello screen vengono scalati automaticamente</remarks>
    Public Overrides Sub SetRenderFlag(x As Integer, y As Integer)
        'imposta la render flag
        RenderGrid.Select(x - GetScreenX(), y - GetScreenY())
    End Sub

    ''' <summary>
    ''' Rimuove la renderflag al tile
    ''' </summary>
    ''' <param name="c">Cordinata di cui rimuovere la renderflag</param>
    ''' <remarks>Gli offset dello screen vengono scalati automaticamente</remarks>
    Public Overrides Sub RemoveRenderFlag(c As ILocated)
        'rimuove la render flag
        RenderGrid.DeSelect(c.GetX - GetScreenX(), c.GetY - GetScreenY())
    End Sub
    ''' <summary>
    ''' Rimuove la renderflag al tile
    ''' </summary>
    ''' <param name="x">Cordinata X di cui rimuovere la renderflag</param>
    ''' <param name="y">Cordinata Y di cui rimuovere la renderflag</param>
    ''' <remarks>Gli offset dello screen vengono scalati automaticamente</remarks>
    Public Overrides Sub RemoveRenderFlag(x As Integer, y As Integer)
        'rimuove la render flag
        RenderGrid.DeSelect(x - GetScreenX(), y - GetScreenY())
    End Sub
End Class
