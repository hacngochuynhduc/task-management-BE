using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STEAMHOUSE.Base.Models;

public interface IEntity<T>
{
    
    // Mọi Entity đều có khóa chính, Dùng Generic cho nó linh hoạt kiểu đầu vào
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    T Id { get; set; }
}