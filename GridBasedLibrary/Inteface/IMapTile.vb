''' <summary>
''' Interfaccia che rappresenta una piastrella in una mappa
''' </summary>
Public Interface IMapTile
    Inherits ILocated

    ''' <summary>
    ''' Restituisce la mappa di appartenenza
    ''' </summary>
    ''' <returns>Mappa</returns>
    Function GetMap() As IMap
    ''' <summary>
    ''' Restituisce il tile sulla piastrella
    ''' </summary>
    ''' <returns>Il tile</returns>
    ''' <remarks>Se il tile è nothing viene restituito Default Tile di Map</remarks>
    Function GetTile() As ITile

    ''' <summary>
    ''' Imposta la piastrella sull' imapTile
    ''' </summary>
    ''' <param name="tile">Tile da impostare</param>
    ''' <remarks>Gli aggiornamenti e il lancio degli eventi vengono eseguiti automaticamente</remarks>
    Sub SetTile(tile As ITile)
    ''' <summary>
    ''' Imposta la piastrella sull' imaptile in modo insicuro
    ''' </summary>
    ''' <param name="tile">Tile da impostare</param>
    ''' <remarks>Gli eventi non vengono eseguiti</remarks>
    Sub SetUnsecureTile(tile As ITile)
    ''' <summary>
    ''' Rimuove il tile
    ''' </summary>
    ''' <remarks>Viene aggiornato la renderFlag e attivati gli eventi</remarks>
    Sub RemoveTile()
    ''' <summary>
    ''' Rimuove il tile in modo insicuro
    ''' </summary>
    ''' <remarks>Non vengono aggiornati la renderFlag o attivati gli eventi</remarks>
    Sub RemoveUnsecureTile()

    ''' <summary>
    ''' Restituisce True se c'è un tile
    ''' </summary>
    ''' <returns>True il tile non è nothing</returns>
    Function HasTile() As Boolean

    ''' <summary>
    ''' Inizializza il mapTile e il tile
    ''' </summary>
    Sub Init()
    ''' <summary>
    ''' Aggiorna il tile
    ''' </summary>
    Sub UpdateTile()

    ''' <summary>
    ''' Restituisce true se è presente un attore, altrimenti false
    ''' </summary>
    ''' <returns>True se è presente un attore, altrimenti false</returns>
    Function HasActor() As Boolean
    ''' <summary>
    ''' Restituisce l'attore se ne è presente, altrimenti nothing
    ''' </summary>
    ''' <returns>Attore</returns>
    Function GetActor() As IActor
    ''' <summary>
    ''' Imposta l'attore in modo insicuro
    ''' </summary>
    ''' <param name="act">Attore da impostare</param>
    Sub SetActor(act As IActor)
    ''' <summary>
    ''' Verifica se l'attore può spostarsi qui
    ''' </summary>
    ''' <param name="act">Attore da verificare</param>
    ''' <returns>True se può entrare, altrimenti false</returns>
    Function CanActorEnter(act As IActor) As Boolean


End Interface
