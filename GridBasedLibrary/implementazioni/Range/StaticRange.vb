''' <summary>
''' Rappresenta un range
''' </summary>
Public Class StaticRange
    Implements IRange

    ''' <summary>
    ''' Ottiene o imposta il valore Minimo
    ''' </summary>
    Protected Min As Integer
    ''' <summary>
    ''' Ottiene o imposta il valore massimo
    ''' </summary>
    Protected Max As Integer

    Private Shared _byteRange As StaticRange = New StaticRange(0, 255)
    ''' <summary>
    ''' Ottiene un range per i byte
    ''' </summary>
    ''' <value>0-255</value>
    ''' <returns>0-255</returns>
    Public Shared ReadOnly Property ByteRange As StaticRange
        Get
            'restituisce il range per i Byte
            Return _byteRange
        End Get
    End Property
    Private Shared _integerRange As StaticRange = New StaticRange(Integer.MinValue, Integer.MaxValue)
    ''' <summary>
    ''' Ottiene un range per i integer
    ''' </summary>
    ''' <value><see cref="Integer.MinValue">Integer.MinValue</see>-<see cref="Integer.MaxValue">Integer.MaxValue</see></value>
    ''' <returns><see cref="Integer.MinValue">Integer.MinValue</see>-<see cref="Integer.MaxValue">Integer.MaxValue</see></returns>
    Public Shared ReadOnly Property IntegerRange As StaticRange
        Get
            'restituisce il range per i integer
            Return _integerRange
        End Get
    End Property
    Private Shared _shortRange As StaticRange = New StaticRange(Short.MinValue, Short.MaxValue)
    ''' <summary>
    ''' Ottiene un range per i byte
    ''' </summary>
    ''' <value><see cref="Int16.MinValue">Short.MinValue</see>-<see cref="Int16.MaxValue">Short.MaxValue</see></value>
    ''' <returns><see cref="Int16.MinValue">Short.MinValue</see>-<see cref="Int16.MaxValue">Short.MaxValue</see></returns>
    Public Shared ReadOnly Property ShortRange As StaticRange
        Get
            'restituisce il range per i short
            Return _shortRange
        End Get
    End Property
    Private Shared _ushortRange As StaticRange = New StaticRange(UShort.MinValue, UShort.MaxValue)
    ''' <summary>
    ''' Ottiene un range per i ushort
    ''' </summary>
    ''' <value><see cref="UInt16.MinValue">UShort.MinValue</see>-<see cref="UInt16.MaxValue">UShort.MaxValue</see></value>
    ''' <returns><see cref="UInt16.MinValue">UShort.MinValue</see>-<see cref="UInt16.MaxValue">UShort.MaxValue</see></returns>
    Public Shared ReadOnly Property UShortRange As StaticRange
        Get
            'restituisce il range per i ushort
            Return _ushortRange
        End Get
    End Property
    Private Shared _SByteRange As StaticRange = New StaticRange(SByte.MinValue, SByte.MaxValue)
    ''' <summary>
    ''' Ottiene un range per i SByte
    ''' </summary>
    ''' <value><see cref="SByte.MinValue">SByte.MinValue</see>-<see cref="SByte.MaxValue">SByte.MaxValue</see></value>
    ''' <returns><see cref="SByte.MinValue">SByte.MinValue</see>-<see cref="SByte.MaxValue">SByte.MaxValue</see></returns>
    Public Shared ReadOnly Property SByteRange As StaticRange
        Get
            'restituisce il range per i SByte
            Return _SByteRange
        End Get
    End Property

    ''' <summary>
    ''' Crea una nuova istanza di Range
    ''' </summary>
    ''' <param name="Min">Valore minimo</param>
    ''' <param name="Max">Valore massimo</param>
    Public Sub New(Min As Integer, Max As Integer)
        'imposta Min e Max
        Me.Min = Min
        Me.Max = Max
        'controlla i valore
        Check()
    End Sub

    ''' <summary>
    ''' Ottiene il valore minimo
    ''' </summary>
    ''' <returns>Il valore minimo</returns>
    Overridable Function GetMin() As Integer Implements IRange.GetMin
        'Restituisce il valore minimo
        Return Min
    End Function
    ''' <summary>
    ''' Ottiene il valore massimo
    ''' </summary>
    ''' <returns>Il valore massimo</returns>
    Overridable Function GetMax() As Integer Implements IRange.GetMax
        'Restituisce il valore massimo
        Return Max
    End Function
    ''' <summary>
    ''' Ottiene la dimensione del range
    ''' </summary>
    ''' <returns>Dimensioni del range</returns>
    ''' <remarks>Max-Min+1</remarks>
    Overridable Function GetSize() As UInteger Implements IRange.GetSize
        'Restituisce le dimensioni
        Return Max - Min + 1
        REM +1 per evitare gli errori della staccionata
    End Function
    ''' <summary>
    ''' Ottiene il range
    ''' </summary>
    ''' <returns>Il range</returns>
    ''' <remarks>I tipo di valore restituito può variare a seconda dell' implementazione</remarks>
    Overridable Function GetRange() As IRange Implements IRange.GetRange
        'restituisce se stesso(me)
        Return Me
    End Function

    ''' <summary>
    ''' Verifica che il valore è compreso nel range
    ''' </summary>
    ''' <param name="value">Valore da verificare</param>
    ''' <returns>True se è compreso, altrimenti false</returns>
    Overridable Function CheckValue(value As Integer) As Boolean Implements IRange.CheckValue
        'verifica che il valore sia compreso nell' intervallo
        Return Min <= value And value <= Max
    End Function

    ''' <summary>
    ''' Verifica che Min e Max siano corretti
    ''' </summary>
    Protected Overridable Sub Check()
        'verifica che Min sia maggiore di max per invertirli
        If Min > Max Then
            'li scambia attraverso l'uso della terza variabile
            Min = Min Xor Max
            Max = Max Xor Min
            Min = Min Xor Max
        End If
    End Sub

    ''' <summary>
    ''' Converte in rappresentazione string questo range
    ''' </summary>
    ''' <returns>[Min-Max]</returns>
    Public Overrides Function ToString() As String
        'compone la stringa secondo la sintassi
        Return String.Format("[{0}-{1}]", Min, Max)
    End Function

    Public Shared Operator >(ByVal left As StaticRange, ByVal right As IRange) As Boolean
        'restituisce true se left ha un size maggiore rispetto a right
        Return left.GetSize > right.GetSize
    End Operator
    Public Shared Operator <(ByVal left As StaticRange, ByVal right As IRange) As Boolean
        'restituisce true se left ha un size minore rispetto a right
        Return left.GetSize < right.GetSize
    End Operator
    Public Shared Operator <>(ByVal left As StaticRange, ByVal right As IRange) As Boolean
        'restituisce false se sono uguali con i limiti
        Return left.Min <> right.GetMin Or left.Max <> right.GetMax
    End Operator
    Public Shared Operator =(ByVal left As StaticRange, ByVal right As IRange) As Boolean
        'restituisce true se sono uguali con i limiti
        Return left.Min = right.GetMin And left.Max = right.GetMax
    End Operator
    Public Shared Operator >(ByVal left As IRange, ByVal right As StaticRange) As Boolean
        'restituisce true se left ha un size maggiore rispetto a right
        Return left.GetSize > right.GetSize
    End Operator
    Public Shared Operator <(ByVal left As IRange, ByVal right As StaticRange) As Boolean
        'restituisce true se left ha un size minore rispetto a right
        Return left.GetSize < right.GetSize
    End Operator
    Public Shared Operator <>(ByVal left As IRange, ByVal right As StaticRange) As Boolean
        'restituisce false se sono uguali con i limiti
        Return left.GetMin <> right.Min Or left.GetMax <> right.Max
    End Operator
    Public Shared Operator =(ByVal left As IRange, ByVal right As StaticRange) As Boolean
        'restituisce true se sono uguali con i limiti
        Return left.GetMin = right.Min And left.GetMax = right.Max
    End Operator
    Public Shared Operator &(ByVal left As StaticRange, ByVal right As IRange) As StaticRange
        'restituisce unione.
        'Nota: se abbiamo 2 range come
        '|----------| |-----------|
        'Vengono uniti cosi
        '|------------------------|
        'Aggiungendo lo spazio
        '           |-|    
        Return New StaticRange(Math.Min(left.Min, right.GetMin), Math.Max(left.Max, right.GetMax))
    End Operator
    Public Shared Operator &(ByVal left As IRange, ByVal right As StaticRange) As StaticRange
        'restituisce unione.
        'Nota: se abbiamo 2 range come
        '|----------| |-----------|
        'Vengono uniti cosi
        '|------------------------|
        'Aggiungendo lo spazio
        '           |-|    
        Return New StaticRange(Math.Min(left.GetMin, right.Min), Math.Max(left.GetMax, right.Max))
    End Operator
End Class
