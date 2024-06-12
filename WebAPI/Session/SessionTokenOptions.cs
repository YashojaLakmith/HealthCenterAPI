namespace WebAPI.Session;

public class SessionTokenOptions
{
    private uint _max = 64;
    private uint _min = 32;

    public uint MaxTokenLengthInBytes
    {
        get { return _max; }
        set { SetMax(value); }
    }

    public uint MinTokenLengthInBytes
    {
        get { return _min; }
        set { SetMin(value); }
    }
    public TimeSpan SlidingExpirationTime { get; set; } = TimeSpan.FromMinutes(30);

    private void SetMax(uint value)
    {
        if (value <= _min)
        {
            _max = _min;
            return;
        }

        _max = value;
    }

    private void SetMin(uint value)
    {
        if (value >= _max)
        {
            _min = _max;
            return;
        }

        if (value < _min)
        {
            return;
        }

        _min = value;
    }
}
