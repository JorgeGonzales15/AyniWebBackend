using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Ayni.Domain.Repositories;
using AyniWebBackend.Ayni.Domain.Services;
using AyniWebBackend.Ayni.Domain.Services.Communication;

namespace AyniWebBackend.Ayni.Services;

public class OrderService : IOrderService
{
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;

    public OrderService(IUserRepository userRepository, IProductRepository productRepository, IUnitOfWork unitOfWork, IOrderRepository orderRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> ListAsync()
    {
        return await _orderRepository.ListAsync();
    }

    public async Task<IEnumerable<Order>> ListByUserIdAsync(int userId)
    {
        return await _orderRepository.FindByUserIdAsync(userId);
    }

    public async Task<OrderResponse> SaveAsync(Order order)
    {
        // Validate UserId
        var existingUser = await 
            _userRepository.FindByIdAsync(order.UserId);
        if (existingUser == null)
            return new OrderResponse("Invalid User");
        try
        {
            // Add Tutorial
            await _orderRepository.AddAsync(order);
 
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
 
            // Return response
            return new OrderResponse(order);
        }
        catch (Exception e)
        {
            // Error Handling
            return new OrderResponse($"An error occurred when saving the category: {e.Message}");
        }
    }

    public async Task<OrderResponse> UpdateAsync(int orderId, Order order)
    {
        var existingOrder = await 
            _orderRepository.FindByIdAsync(orderId);
 
        // Validate Tutorial
        if (existingOrder == null)
            return new OrderResponse("Tutorial not found.");
 
        // Modify Fields
        existingOrder.Description = order.Description;
        existingOrder.Status = order.Status;
        existingOrder.OrderedDate = order.OrderedDate;
        existingOrder.TotalPrice = order.TotalPrice;
        existingOrder.Status = order.Status;
        existingOrder.PaymentMethod = order.PaymentMethod;
        existingOrder.UserId = order.UserId;
        existingOrder.ProductId = order.ProductId;
 
        
        try
        {
            _orderRepository.Update(existingOrder);
            await _unitOfWork.CompleteAsync();
            return new OrderResponse(existingOrder);
 
        }
        catch (Exception e)
        {
            // Error Handling
            return new OrderResponse($"An error occurred when updating the category: {e.Message}");
        }
    }

    public async Task<OrderResponse> DeleteAsync(int orderId)
    {
        var existingOrder = await 
            _orderRepository.FindByIdAsync(orderId);
 
        // Validate Tutorial
        if (existingOrder == null)
            return new OrderResponse("Tutorial not found.");
 
        try
        {
            _orderRepository.Remove(existingOrder);
            await _unitOfWork.CompleteAsync();
            return new OrderResponse(existingOrder);
 
        }
        catch (Exception e)
        {
            // Error Handling
            return new OrderResponse($"An error occurred when deleting the category: {e.Message}");
        }
    }
}