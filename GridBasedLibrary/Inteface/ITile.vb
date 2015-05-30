''' <summary>
''' Interfaccia che rappresenta un tile
''' </summary>
Public Interface ITile

    ''' <summary>
    ''' Restituisce una copia di se stesso
    ''' </summary>
    ''' <returns>Una copia di se stesso</returns>
    Function GetCopy() As ITile
    ''' <summary>
    ''' Restituisce una copia di se stesso se non è statico oppure se stesso
    ''' </summary>
    ''' <returns>Se statico restituisce se stesso, invece se non statico una copia</returns>
    ''' <remarks></remarks>
    Function GetIstance() As ITile
    ''' <summary>
    ''' Restituisce true se è condiviso
    ''' </summary>
    ''' <returns>True se è condiviso</returns>
    Function IsStatic() As Boolean

    ''' <summary>
    ''' Restituisce il punteggio usato dai pathFinder
    ''' </summary>
    ''' <param name="act">Il punteggio può variare per l'attore</param>
    ''' <returns>Il punteggio</returns>
    ''' <remarks>Il punteggio potrebbe dipendere dall' attore</remarks>
    Function GetScoreForPathFinder(act As IActor) As Single
    ''' <summary>
    ''' Ottiene il nome assegnato al tile
    ''' </summary>
    ''' <returns>Il nome</returns>
    Function GetName() As String

    ''' <summary>
    ''' Inizializza il tile con il maptile di riferimento
    ''' </summary>
    ''' <param name="ref">MapTile di riferimento</param>
    Sub Init(ref As IMapTile)

    ''' <summary>
    ''' Aggiorna il tile
    ''' </summary>
    ''' <param name="ref">MapTile di riferimento</param>
    Sub Update(ref As IMapTile)

    ''' <summary>
    ''' Verifica che i 2 tile sono uguali o no
    ''' </summary>
    ''' <param name="tile2">Secondo tile</param>
    ''' <returns>True se sono uguali, altrimenti false</returns>
    Function IsEqual(tile2 As ITile) As Boolean
    ''' <summary>
    ''' Restituisce true se sono uguali dal punto di vista grafico
    ''' </summary>
    ''' <param name="tile2">Secondo tile</param>
    ''' <returns>True se sono uguali dal punto di vista grafico</returns>
    Function IsRenderEqual(tile2 As ITile) As Boolean

    ''' <summary>
    ''' Evento che si verifica quando un attore sta per entrare in questo tile
    ''' </summary>
    ''' <param name="act">Attore che sta per entrare</param>
    ''' <param name="cancel">True se cancellare l'evento</param>
    ''' <param name="from">MapTile di partenza</param> 
    ''' <param name="dest">MapTile di destinazione</param>
    Event ActorEntering(act As IActor, from As IMapTile, dest As IMapTile, ByRef cancel As Boolean)
    ''' <summary>
    ''' Evento che si verifica quando un attore è entrato
    ''' </summary>
    ''' <param name="act">Attore che è entrato</param>
    ''' <param name="from">MapTile di partenza</param> 
    ''' <param name="dest">MapTile di destinazione</param>
    Event ActorEntered(act As IActor, from As IMapTile, dest As IMapTile)

    ''' <summary>
    ''' Lancia l'evento che si verifica quando un attore sta per entrare in questo tile
    ''' </summary>
    ''' <param name="act">Attore che si spostato</param>
    ''' <param name="dest">MapTile di destinazione</param>
    ''' <returns>True se è stato rifiutato</returns>
    Function OnActorEntering(act As IActor, from As IMapTile, dest As IMapTile) As Boolean
    ''' <summary>
    ''' Lancia l'evento che si verifica quando un attore è entrato in questo tile
    ''' </summary>
    ''' <param name="act">Attore che ha compiuto l'azione</param>
    ''' <param name="from">TileMap di origine</param>
    ''' <param name="dest">MapTile di destinazione</param>
    Sub OnActorEntered(act As IActor, from As IMapTile, dest As IMapTile)

    ''' <summary>
    ''' Evento che si verifica quando un attore sta per lasciare questo tile
    ''' </summary>
    ''' <param name="act">Attore che sta per entrare</param>
    ''' <param name="cancel">True se cancellare l'evento</param>
    ''' <param name="from">MapTile di partenza</param> 
    ''' <param name="dest">MapTile di destinazione</param>
    Event ActorLeaving(act As IActor, from As IMapTile, dest As IMapTile, ByRef cancel As Boolean)
    ''' <summary>
    ''' Evento che si verifica quando un attore ha lasciato questo tile
    ''' </summary>
    ''' <param name="act">Attore che è entrato</param>
    ''' <param name="from">MapTile di partenza</param> 
    ''' <param name="dest">MapTile di destinazione</param>
    Event ActorLeaved(act As IActor, from As IMapTile, dest As IMapTile)

    ''' <summary>
    ''' Lancia l'evento che si verifica quando un attore sta per lasciare questo tile
    ''' </summary>
    ''' <param name="act">Attore che si spostato</param>
    ''' <param name="dest">MapTile di destinazione</param>
    ''' <returns>True se è stato rifiutato</returns>
    Function OnActorLeaving(act As IActor, from As IMapTile, dest As IMapTile) As Boolean
    ''' <summary>
    ''' Lancia l'evento che si verifica quando un attore ha lasciato questo tile
    ''' </summary>
    ''' <param name="act">Attore che ha compiuto l'azione</param>
    ''' <param name="from">TileMap di origine</param>
    ''' <param name="dest">MapTile di destinazione</param>
    Sub OnActorLeaved(act As IActor, from As IMapTile, dest As IMapTile)

    ''' <summary>
    ''' Restituisce true se l'attore può entrare nel tile
    ''' </summary>
    ''' <param name="act">Attore da verificare</param>
    ''' <returns>True se può entrare</returns>
    Function CanActorEnter(act As IActor) As Boolean

End Interface
