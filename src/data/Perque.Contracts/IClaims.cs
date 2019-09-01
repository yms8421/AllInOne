namespace Perque.Contracts
{
    /// <summary>
    /// Bu interface herhangi bir DI sürecinde bulunan bir class'a inject edilirse, o an isteği atan kullanıcının id ve mail adresine erişebilir
    /// </summary>
    public interface IClaims
    {
        int UserId { get; }
        string Mail { get; }
    }
}
