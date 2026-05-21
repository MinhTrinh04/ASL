CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
5.1 Thiết kế kiến trúc
5.1.1 Lựa chọn kiến trúc phần mềm
Trò chơi được phát triển dựa trên kiến trúc Component-Based, một mô hình
thiết kế phổ biến trong các game engine như Unity, phù hợp với các ứng dụng VR
yêu cầu tính linh hoạt và tương tác thời gian thực. Kiến trúc này được áp dụng
bằng cách tổ chức mã nguồn thành các component độc lập, sử dụng các script

```
MonoBehaviour gắn vào GameObjects để quản lý cả dữ liệu (như trạng thái cử chỉ
```

```
tay, sức khỏe, thông số) và logic xử lý (như điều khiển di chuyển, tấn công, tương
```

```
tác giao diện người dùng). Mỗi component được thiết kế để thực hiện một chức
```

năng cụ thể, ví dụ, xử lý cử chỉ tay để bắn súng, điều khiển phi thuyền vũ trụ, quản
lý hành vi của các loại kẻ địch, hoặc xử lý các nút bấm trong UI. Cách tiếp cận này
cho phép triển khai nhanh các tính năng như dịch chuyển tức thời, tấn công laser,
hoặc tương tác UI, đồng thời duy trì tính mô-đun để dễ dàng mở rộng hoặc điều
chỉnh.
a, Thành phần chính của Kiến trúc
Kiến trúc Component-Based được xây dựng dựa trên hai thành phần chính:
• GameObjects: Các đối tượng trong trò chơi, đóng vai trò như các thực thể
chứa các component, ví dụ như nhân vật người chơi, phi thuyền vũ trụ, bốn
loại kẻ địch, điểm chuyển tiếp, hoặc các vật thể môi trường. Mỗi GameObject
được gắn các component để xác định hành vi và trạng thái của nó.
• Components: Các script MonoBehaviour gắn vào GameObjects, chứa cả dữ

```
liệu (như vị trí, sức khỏe, trạng thái cử chỉ) và logic xử lý (như di chuyển, tấn
```

```
công, hoặc tương tác UI). Các component được thiết kế độc lập, cho phép dễ
```

dàng thêm hoặc sửa đổi tính năng mà không ảnh hưởng đến toàn bộ hệ thống.
b, GameObjects trong Trò chơi
GameObjects được sử dụng để đại diện cho các đối tượng chính trong ba màn
chơi của trò chơi:
• Nhân vật người chơi: Xuất hiện trong màn 1 và màn 3, được điều khiển bằng
cử chỉ tay để thực hiện các hành động như di chuyển, bắn súng, hoặc chắn
đạn. Các component như PlayerAction và PlayerHealthController được gắn để
quản lý hành động và sức khỏe, cho phép người chơi tương tác với kẻ địch
hoặc môi trường.
38
CHƯƠNG 5. THỰC NGHIỆM VÀ ĐÁNH GIÁ
• phi thuyền vũ trụ: Có mặt trong màn 2, cho phép người chơi điều khiển để di
chuyển, xoay, và bắn trong không gian. Các component như SpaceShipCon-
troller và PlayerShipAction được gắn để xử lý các hành động này, đảm bảo trải
nghiệm điều khiển mượt mà.
• Kẻ địch: Bao gồm bốn loại, mỗi loại có hành vi riêng biệt:
– HoverBot: Kẻ địch di chuyển lơ lửng, xuất hiện ở màn 1 và màn 3, tấn
công người chơi bằng các đòn bắn cơ bản. Component EnemyControl và
DetectionModule được sử dụng để điều khiển di chuyển và nhắm mục
tiêu.
– Turret: Kẻ địch cố định, bắn đạn tự động khi phát hiện người chơi, xuất
hiện ở màn 1 và màn 3. Component LazerAttackController được gắn để
quản lý tấn công laser.
– SpaceFighterShip: Phi thuyền địch di chuyển nhanh, xuất hiện ở màn 2,
nhắm vào phi thuyền người chơi với các đòn tấn công linh hoạt. Com-
ponent DetectionModule và EnemyControl được sử dụng để xử lý hành
vi.
– Boss cuối: Kẻ địch mạnh nhất ở màn 3, yêu cầu người chơi sử dụng tất cả
kỹ năng để đánh bại. Component DetectionModule và LazerAttackCon-
troller được gắn để thực hiện các đòn tấn công phức tạp.
• Điểm chuyển tiếp: Các đối tượng như phi thuyền vũ trụ ở màn 1 hoặc cánh
cổng ở màn 2, cho phép chuyển giữa các màn. Component GameManager
được sử dụng để kiểm tra tương tác với các điểm này.
• Môi trường: Các vật thể như địa hình, chướng ngại vật, hoặc tàn tích, được
gắn Transform và Collider để hỗ trợ tương tác vật lý với người chơi, phi thuyền,
hoặc kẻ địch.
c, Components
Các component được triển khai dưới dạng script MonoBehaviour, mỗi script
chứa dữ liệu và logic để thực hiện một chức năng cụ thể, đảm bảo tính độc lập và
dễ tái sử dụng. Các component chính bao gồm:
• Components của Unity:
– Transform: Lưu trữ và cập nhật vị trí, xoay, và tỷ lệ của GameObjects, ví
dụ, di chuyển nhân vật người chơi theo cử chỉ trỏ tay hoặc xoay phi thuyền
vũ trụ theo cử chỉ úp lòng bàn tay.
– Rigidbody: Quản lý vật lý, như áp dụng trọng lực cho nhân vật ở màn 1
39
