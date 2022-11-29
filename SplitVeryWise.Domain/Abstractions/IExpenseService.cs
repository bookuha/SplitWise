using SplitVeryWise.Application.Contracts.DTOs.Expense;
using SplitVeryWise.Application.Contracts.DTOs.ExpenseLine;

namespace SplitVeryWise.Domain.Abstractions;

public interface IExpenseService
{
    Task<IEnumerable<ExpenseResponse>> GetExpenses();

    Task<IEnumerable<ExpenseResponse>> GetExpensesByGroup(int groupId);

    Task<ExpenseResponse> GetExpenseById(int id);

    Task<ExpenseResponse> CreateExpense(ExpenseCreateRequest createRequest);

    Task<ExpenseResponse> UpdateExpense(ExpenseUpdateRequest updateRequest);

    Task<ExpenseResponse> DeleteExpense(int id);

    Task<IEnumerable<ExpenseLineResponse>> GetExpenseLines();

    Task<IEnumerable<ExpenseLineResponse>> GetExpenseLinesByExpense(int expenseId);

    Task<ExpenseLineResponse> GetExpenseLineById(int expenseLineId);

    Task<ExpenseLineResponse> CreateExpenseLine(ExpenseLineCreateRequest createRequest);
    // + Author id so only expense author can create expense lines in his expenses
    // The victim must be in the group that expense belongs to

    Task<ExpenseLineResponse> UpdateExpenseLine(ExpenseLineUpdateRequest updateRequest);

    Task<ExpenseLineResponse> DeleteExpenseLine(int expenseLineId);
}