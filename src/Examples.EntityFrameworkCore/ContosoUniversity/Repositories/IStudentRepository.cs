using Examples.EntityFrameworkCore.ContosoUniversity.Models;

namespace Examples.EntityFrameworkCore.ContosoUniversity.Repositories;

public interface IStudentRepository
{
    public Task<IEnumerable<Student>> FindAllAsync(CancellationToken cancelToken = default);

    public Task<Student?> FindAsync(int id, CancellationToken cancelToken = default);

    public Task AddAsync(Student student, CancellationToken cancelToken = default);

    public Task UpdateAsync(int id, Student modifier, CancellationToken cancelToken = default);

    public Task RemoveAsync(int id, CancellationToken cancelToken = default);

}
