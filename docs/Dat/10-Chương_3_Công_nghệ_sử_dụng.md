# Chương 3: Công Nghệ Sử Dụng

Trong quá trình phát triển tựa game bắn súng góc nhìn thứ nhất trong môi trường thực tế ảo, một yêu cầu quan trọng là xây dựng hệ thống điều khiển tự nhiên, tăng tính nhập vai và giảm sự phụ thuộc vào tay cầm truyền thống. Để giải quyết vấn đề này, thư viện **Unity XR Hands** được sử dụng để triển khai toàn bộ các cơ chế nhận diện cử chỉ tay (hand gesture recognition) trong game, bao gồm bắn súng, di chuyển nâng cao (lướt và dịch chuyển), và điều khiển phương tiện. 

**Unity XR Hands** (được tài liệu hóa tại *Unity Documentation* [12]) cung cấp khả năng theo dõi vị trí khớp bàn tay (joint tracking) và nhận diện trạng thái tay (hand pose) thông qua dữ liệu từ các cảm biến VR, như camera hồng ngoại trên kính **Meta Quest**. Cụ thể, thư viện hỗ trợ phát hiện các cử chỉ như trỏ ngón tay để ngắm bắn, tạo hình khẩu súng bằng hai tay để khai hỏa, nghiêng lòng bàn tay để kích hoạt cơ chế lướt, trỏ tay để dịch chuyển tức thời, và nghiêng tay để điều hướng phương tiện.

> **Hình 3.1:** *Hệ thống nhận diện cử chỉ tay Gesture*

**Unity XR Hands** giải quyết ba vấn đề chính trong đồ án:
1. **Tăng tính nhập vai:** Cho phép người chơi tương tác trực quan qua cử chỉ tay. Ví dụ: người chơi có thể ngắm bắn bằng cách trỏ ngón tay hoặc khai hỏa bằng cách tạo hình khẩu súng, mang lại cảm giác như đang thực sự sử dụng vũ khí trong không gian ảo.
2. **Giảm độ phức tạp trong điều khiển:** Loại bỏ nhu cầu ghi nhớ tổ hợp nút bấm trên tay cầm, vốn có thể gây khó khăn cho người chơi mới.
3. **Đảm bảo tính tương thích:** Tương thích tốt với các thiết bị VR phổ thông như **Meta Quest**, vốn đã hỗ trợ hand tracking sẵn có từ phần cứng. 

Ngoài ra, tính năng *Gesture Visualization UI* của **Unity XR Hands** cho phép hiển thị trực quan các cử chỉ tay trong không gian **3D**, giúp lập trình viên dễ dàng kiểm tra và tinh chỉnh cử chỉ trong quá trình phát triển, đảm bảo độ chính xác và phản hồi nhanh. Ví dụ, trong cơ chế điều khiển phương tiện, **Unity XR Hands** nhận diện cử chỉ nghiêng tay để điều hướng phi thuyền bay, nâng/hạ tay để thay đổi độ cao, và nắm tay để tăng tốc, tạo ra trải nghiệm điều khiển tự nhiên và trực quan.

Lý do lựa chọn cách tiếp cận hiện tại với **Unity XR Hands**: Việc tùy chỉnh cử chỉ trong **Unity XR Hands** (như trỏ ngón tay, nghiêng tay) được chọn vì đáp ứng tốt các yêu cầu cụ thể của game FPS VR, từ bắn súng, di chuyển, đến điều khiển phương tiện, mang lại trải nghiệm nhập vai và đa dạng. So với việc chỉ dùng cử chỉ mặc định, cách tiếp cận này linh hoạt hơn và phù hợp với lối chơi hành động nhanh của FPS. So với tùy chỉnh cử chỉ đơn giản, phương pháp này tăng tính phong phú cho tương tác, giúp người chơi cảm nhận được sự tự nhiên trong từng hành động. Cuối cùng, việc không dùng cảm biến bên ngoài đảm bảo tính khả thi trên các thiết bị VR phổ thông, phù hợp với mục tiêu tối ưu hóa của đồ án.

> **Hình 3.2:** *Hệ thống Gesture hỗ trợ việc tùy chỉnh cử chỉ*

Sau khi phân tích các tính năng tiềm năng cho tựa game FPS VR, một tập hợp con các tính năng được lựa chọn để triển khai, tập trung vào việc sử dụng **Unity XR Hands** để đảm bảo trải nghiệm chơi game mượt mà trên các thiết bị VR phổ thông như **Meta Quest**:
* **(1) Cơ chế bắn súng cơ bản:** Sử dụng **Unity XR Hands** để nhận diện các cử chỉ như trỏ ngón tay để ngắm bắn và tạo hình khẩu súng bằng hai tay để khai hỏa, mang lại cảm giác tự nhiên như đang sử dụng vũ khí thực sự.
* **(2) Hệ thống di chuyển nâng cao:** Tích hợp hai cơ chế: lướt (dash) (nghiêng lòng bàn tay để kích hoạt) giúp người chơi né đạn hoặc tiếp cận kẻ địch nhanh chóng, và dịch chuyển (teleport) (trỏ tay để chọn vị trí) nhằm giảm nguy cơ say VR cho người chơi mới. Cả hai đều được triển khai với **Unity XR Hands** để đảm bảo tính trực quan và linh hoạt trong không gian ba chiều.
* **(3) Điều khiển phương tiện:** Cho phép người chơi vận hành phi thuyền bay bằng cách nghiêng tay để điều hướng, nâng/hạ tay để thay đổi độ cao, và nắm tay để tăng tốc, tận dụng khả năng nhận diện cử chỉ của **Unity XR Hands** để tạo trải nghiệm điều khiển nhập vai.

Tựa game FPS VR này tận dụng **Unity XR Hands** để mang đến một trải nghiệm hành động độc đáo, kết hợp sự quen thuộc của thể loại FPS với sự đột phá của điều khiển cử chỉ, tạo nên điểm nhấn trong thị trường game VR. Bằng cách tối ưu hóa cho thiết bị VR phổ thông, trò chơi không chỉ thu hút người chơi yêu thích hành động mà còn đặt nền móng cho các ứng dụng tương tác cử chỉ tay trong các lĩnh vực như đào tạo mô phỏng hoặc giao diện điều khiển công nghiệp, hứa hẹn một bước tiến mới trong công nghệ VR.
