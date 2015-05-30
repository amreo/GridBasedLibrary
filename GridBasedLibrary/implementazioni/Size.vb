''' <summary>
''' Rappresenta le dimensioni di un rettangolo
''' </summary>
Public Structure Size

    ''' <summary>
    ''' Ottiene o imposta la larghezza
    ''' </summary>
    Private width As UInteger
    ''' <summary>
    ''' Ottiene o imposta l'altezza
    ''' </summary>
    Private height As UInteger

    ''' <summary>
    ''' Crea una nuova istanza di size
    ''' </summary>
    ''' <param name="width">Larghezza</param>
    ''' <param name="height">Altezza</param>
    Public Sub New(ByVal width As UInteger, height As UInteger)
        'imposta la larghezza e l'altezza
        Me.width = width
        Me.height = height
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di size
    ''' </summary>
    ''' <param name="source">Valore size espresso in |--32bit--width--|--32bit--height--|</param>
    ''' <remarks>E' utile solo nelle serializzazioni</remarks>
    Public Sub New(ByVal source As ULong)
        'scompone source e li imposta
        width = source And &HFFFFFFFF00000000
        height = source And &HFFFFFFFF
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di size
    ''' </summary>
    ''' <param name="source">Valore size espresso in |--32bit--width--|--32bit--height--|</param>
    ''' <remarks>E' utile solo nelle serializzazioni</remarks>
    Public Sub New(ByVal source As Long)
        'scompone source e li imposta
        width = source And &HFFFFFFFF00000000
        height = source And &HFFFFFFFF
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di size
    ''' </summary>
    ''' <param name="source">Valore size espresso in |--16bit--width--|--16bit--height--|</param>
    ''' <remarks>E' utile solo nelle serializzazioni</remarks>
    Public Sub New(ByVal source As Integer)
        'scompone source e li imposta
        width = source And &HFFFF0000
        height = source And &HFFFF
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di size
    ''' </summary>
    ''' <param name="source">Valore size espresso in |--16bit--width--|--16bit--height--|</param>
    ''' <remarks>E' utile solo nelle serializzazioni</remarks>
    Public Sub New(ByVal source As UInteger)
        'scompone source e li imposta
        width = source And &HFFFF0000
        height = source And &HFFFF
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di size
    ''' </summary>
    ''' <param name="source">Valore size espresso in |--8bit--width--|--8bit--height--|</param>
    ''' <remarks>E' utile solo nelle serializzazioni</remarks>
    Public Sub New(ByVal source As Short)
        'scompone source e li imposta
        width = source And &HFF00
        height = source And &HFF
    End Sub
    ''' <summary>
    ''' Crea una nuova istanza di size
    ''' </summary>
    ''' <param name="source">Valore size espresso in |--8bit--width--|--8bit--height--|</param>
    ''' <remarks>E' utile solo nelle serializzazioni</remarks>
    Public Sub New(ByVal source As UShort)
        'scompone source e li imposta
        width = source And &HFF00
        height = source And &HFF
    End Sub

    ''' <summary>
    ''' Ottiene la larghezza di size
    ''' </summary>
    ''' <returns>La larghezza</returns>
    Public Function GetWidth() As UInteger
        'restituisce Width
        Return width
    End Function
    ''' <summary>
    ''' Ottiene l'altezza di size
    ''' </summary>
    ''' <returns>L'altezza</returns>
    Public Function GetHeight() As UInteger
        'restituisce height
        Return height
    End Function
    ''' <summary>
    ''' Ottiene il valore di size usato nelle serializzazioni
    ''' </summary>
    ''' <returns>Il valore di size</returns>
    ''' <remarks>E' usato solo nelle serializzazioni</remarks>
    Public Function GetSizeValue() As ULong
        'restituisce il valore calcolandolo
        Return CLng(width) << 32 Or height
    End Function

    ''' <summary>
    ''' Imposta la larghezza
    ''' </summary>
    ''' <param name="value">Valore da impostare</param>
    Public Sub SetWidth(value As UInteger)
        'imposta la larghezza
        Me.width = value
    End Sub
    ''' <summary>
    ''' Imposta l'altezza
    ''' </summary>
    ''' <param name="value">Valore</param>
    Public Sub SetHeight(value As UInteger)
        'imposta l'altezza
        Me.height = value
    End Sub
End Structure
