      program circle
      real r, area

!     This program reads a real number r and prints
!     the area of the circle with radius r.

      write (*, *) 'Give radius r:'
      read  (*, *) r
      area = 3.14159 * r * r
      write (*, *) 'Area =', area

      stop
      end
