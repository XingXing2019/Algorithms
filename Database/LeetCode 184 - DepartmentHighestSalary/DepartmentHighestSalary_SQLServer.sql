select d1.Name as Department, e1.Name as Employee, e1.Salary from Employee e1 join Department d1 on e1.DepartmentId = d1.Id
where e1.Salary = (select max(Salary) from Employee e2 where e2.DepartmentId = d1.Id);