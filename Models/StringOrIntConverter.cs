using System.Text.Json;
using System.Text.Json.Serialization;

namespace NextBillion.Models;

public class StringOrIntConverter : JsonConverter<StringOrInt>
{
    public override StringOrInt Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.String => new StringOrInt(reader.GetString()!),
            JsonTokenType.Number => new StringOrInt(reader.GetInt32()),
            _ => throw new JsonException($"Unexpected token type: {reader.TokenType}")
        };
    }

    public override void Write(Utf8JsonWriter writer, StringOrInt value, JsonSerializerOptions options)
    {
        if (value.IsString)
        {
            writer.WriteStringValue(value.StringValue);
        }
        else
        {
            writer.WriteNumberValue(value.IntValue);
        }
    }
}

[JsonConverter(typeof(StringOrIntConverter))]
public readonly struct StringOrInt
{
    private readonly string? _stringValue;
    private readonly int _intValue;
    private readonly bool _isString;

    public StringOrInt(string value)
    {
        _stringValue = value ?? throw new ArgumentNullException(nameof(value));
        _intValue = 0;
        _isString = true;
    }

    public StringOrInt(int value)
    {
        _stringValue = null;
        _intValue = value;
        _isString = false;
    }

    public bool IsString => _isString;
    public bool IsInt => !_isString;

    public string StringValue => _isString ? _stringValue! : throw new InvalidOperationException("Value is not a string");
    public int IntValue => !_isString ? _intValue : throw new InvalidOperationException("Value is not an integer");

    public override string ToString()
    {
        return _isString ? _stringValue! : _intValue.ToString();
    }

    public static implicit operator StringOrInt(string value) => new(value);
    public static implicit operator StringOrInt(int value) => new(value);

    public override bool Equals(object? obj)
    {
        if (obj is StringOrInt other)
        {
            if (_isString != other._isString) return false;
            return _isString ? _stringValue == other._stringValue : _intValue == other._intValue;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return _isString ? _stringValue?.GetHashCode() ?? 0 : _intValue.GetHashCode();
    }
}
