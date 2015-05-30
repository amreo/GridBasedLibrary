''' <summary>
''' Rappresenta una mappa usata nelle applicazioni client(dove è richiesto un rendering)
''' </summary>
Public Interface IMapClient
    Inherits IMap

    ''' <summary>
    ''' Imposta la flag per il rendering
    ''' </summary>
    ''' <param name="c">Cordinata da settare</param>
    Sub SetRenderFlag(c As ILocated)
    ''' <summary>
    ''' Imposta la flag per il rendering
    ''' </summary>
    ''' <param name="x">Cordinata X da settare</param>
    ''' <param name="y">Cordinata Y da settare</param>
    Sub SetRenderFlag(x As Integer, y As Integer)
    ''' <summary>
    ''' Imposta la flag per il rendering
    ''' </summary>
    ''' <param name="c">Cordinate da settare</param>
    Sub SetRenderFlag(ParamArray c() As ILocated)

    ''' <summary>
    ''' Rimuove la flag per il rendering
    ''' </summary>
    ''' <param name="c">Cordinata da desettare</param>
    Sub RemoveRenderFlag(c As ILocated)
    ''' <summary>
    ''' Rimuove la flag per il rendering
    ''' </summary>
    ''' <param name="x">Cordinata X da desettare</param>
    ''' <param name="y">Cordinata Y da desettare</param>
    Sub RemoveRenderFlag(x As Integer, y As Integer)
    ''' <summary>
    ''' Rimuove la flag per il rendering
    ''' </summary>
    ''' <param name="c">Cordinate da desettare</param>
    Sub RemoveRenderFlag(ParamArray c() As ILocated)

    ''' <summary>
    ''' Verifica se la cordinata deve essere ri-renderizzata
    ''' </summary>
    ''' <param name="c">Cordinata da verificare</param>
    ''' <returns>True se deve essere ri-renderizzata</returns>
    Function CanRenderUpdate(c As ILocated) As Boolean
    ''' <summary>
    ''' Verifica se la cordinata deve essere ri-renderizzata
    ''' </summary>
    ''' <param name="x">Cordinata X da verificare</param>
    ''' <param name="y">Cordinata Y da verificare</param>
    ''' <returns>True se deve essere ri-renderizzata</returns>
    Function CanRenderUpdate(x As Integer, y As Integer) As Boolean

    ''' <summary>
    ''' Restituisce l'elenco di punti che devono essere ri-renderizzati
    ''' </summary>
    ''' <returns>Cordinate che devono ri-renderizzate</returns>
    Function GetRenderUpdateCoords() As Coord()
End Interface
