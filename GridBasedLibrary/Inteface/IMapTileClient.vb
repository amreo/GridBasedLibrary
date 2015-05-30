''' <summary>
''' Interfaccia che rappresenta un IMapTile nel client
''' </summary>
Public Interface IMapTileClient
    Inherits IMapTile

    ''' <summary>
    ''' Imposta la flag per l'aggiornamento
    ''' </summary>
    Sub SetRenderFlag()
    ''' <summary>
    ''' Rimuove la flag per l'aggiornamento
    ''' </summary>
    Sub RemoveRenderFlag()
    ''' <summary>
    ''' Verifica se deve essere ri-renderderizzato
    ''' </summary>
    ''' <returns>True se deve essere ri-renderizzato</returns>
    Function CanRenderFlag() As Boolean

    ''' <summary>
    ''' Restituisce la mappa usata dal client
    ''' </summary>
    ''' <returns>La mappa</returns>
    Function GetMapClient() As IMapClient
End Interface
